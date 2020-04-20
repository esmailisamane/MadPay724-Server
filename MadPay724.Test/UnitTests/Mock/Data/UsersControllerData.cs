using MadPay724.Data.Dtos.Site.Admin.Users;
using MadPay724.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Test.UnitTests.Mock.Data
{
    public static class UsersControllerData
    {
        public static IEnumerable<User> GetUser()
        {
            var userList = new List<User>()
            {
                new User
                {
                    Id = "9578f766-5d44-4abe-a556-b1b2c257f74a",
                    Datecreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    LastActive = DateTime.Now,
                    PasswordHash =new byte[255],
                    PasswordSalt = new byte[255],
                    UserName = "se@gmail.com",
                    Name = "Holloway Vasquez",
                    PhoneNumber = "55",
                    Address = "55",
                    Gender = true,
                    City = "55",
                    IsActive = true,
                    Status = true,
                    Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            Id = "ba09fde5-3754-4e94-908e-7d1db6fb4aa3",
                            UserId = "9578f766-5d44-4abe-a556-b1b2c257f74a",
                            Datecreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            PublicId = "1",
                            Url = "qq",
                            Alt = "qq",
                            IsMain = true,
                            Description = "qq",
                        }
                    }
                }
            };
            return userList;
        }

        public static UserForDetailedDto GetUserForDetailedDto()
        {
            return new UserForDetailedDto()
            {
                Id = "9578f766-5d44-4abe-a556-b1b2c257f74a",
                UserName = "se@gmail.com",
                Name = "Holloway Vasquez",
                PhoneNumber = "55",
                Address = "55",
                Gender = true,
                City = "55",
                Age = 15,
                LastActive = DateTime.Now,
                PhotoUrl = "qqq"
            };
        }
    }
}