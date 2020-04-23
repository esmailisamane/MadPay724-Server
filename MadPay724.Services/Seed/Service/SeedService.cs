using MadPay724.Common.Helpers;
using MadPay724.Common.Helpers.Interface;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Seed.Interface;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadPay724.Services.Seed.Service
{
    public class SeedService : ISeedService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUtilities _utilities;

        public SeedService(UserManager<User> userManager, IUtilities utilities)
        {
            _userManager = userManager;
            _utilities = utilities;
        }


        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("wwwroot/Files/Json/Seed/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<IList<User>>(userData);
                foreach (var user in users)
                {
                    user.UserName = user.UserName.ToLower();
                    _userManager.CreateAsync(user, "password").Wait();
                }
            }
        }

        public async Task SeedUsersAsync()
        {
            if (!_userManager.Users.Any())
            {
                var userData = await System.IO.File.ReadAllTextAsync("wwwroot/Files/Json/Seed/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<IList<User>>(userData);
                foreach (var user in users)
                {
                    user.UserName = user.UserName.ToLower();
                    await _userManager.CreateAsync(user, "password");
                }
            }

        }
    }


}