using MadPay724.Common.Helpers;
using MadPay724.Common.Helpers.Interface;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Seed.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MadPay724.Services.Seed.Service
{
   public class SeedService : ISeedService
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IUtilities _utilities;
        public SeedService(IUnitOfWork<MadpayDbContext> dbContex, IUtilities utilities)
        {
            _db = dbContex;
            _utilities = utilities;
        }

        public void  SeedUsers()
        {
            var userdata = System.IO.File.ReadAllText("wwwroot/Files/Json/Seed/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<IList<User>>(userdata);

            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                _utilities.CreatePasswordHash("12345", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                user.UserName = user.UserName.ToLower();
                 _db.UserRepository.InsertAsync(user);

            }

            _db.Save();
        }

        public async Task SeedUsersAsync()
        {
            var userdata = System.IO.File.ReadAllText("Files/Json/Seed/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<IList<User>>(userdata);

            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                _utilities.CreatePasswordHash("12345", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                user.UserName = user.UserName.ToLower();
               await _db.UserRepository.InsertAsync(user);

            }
          await  _db.saveAsync();
        }
    }
}
