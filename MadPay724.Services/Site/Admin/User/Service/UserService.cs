using MadPay724.Common.Helpers;
using MadPay724.Common.Helpers.Interface;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Services.Site.Admin.Auth.Service
{
   public class UserService : IUserService
    {

        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IUtilities _utilities;
        public UserService(IUnitOfWork<MadpayDbContext> dbContex, IUtilities utilities)
        {
            _db = dbContex;
            _utilities = utilities;
        }
        public async Task<User> GetUserForPassChange(string id, string password)
        {
            var user = await _db.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            //if (!_utilities.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //    return null;

            return user;

        }

        public async Task<bool> UpdateUserPass(User user, string newPassword)
        {
            byte[] passwordHash, passwordSalt;
            _utilities.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

            //user.PasswordHash = passwordHash;
            //user.PasswordSalt = passwordSalt;
            _db.UserRepository.Update(user);
            return await _db.saveAsync();

            
        }
    }
}
