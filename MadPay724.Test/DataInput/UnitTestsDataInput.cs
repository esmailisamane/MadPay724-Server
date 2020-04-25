using System;
using System.Collections.Generic;
using System.Text;
using MadPay724.Data.Dtos.Common.Token;
using MadPay724.Data.Dtos.Services;
using MadPay724.Data.Dtos.Site.Panel.Photos;
using MadPay724.Data.Dtos.Site.Panel.Roles;
using MadPay724.Data.Dtos.Site.Panel.Users;
using MadPay724.Data.Models;
using Moq;

namespace MadPay724.Test.DataInput
{
    public static class UnitTestsDataInput
    {

        public const string baseRouteV1 = "api/v1/";

        public const string unToken = "";

        public const string aToken =
          "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4M2IwNTQ3My04NjA3LTRkZDUtOWMyZS02ZWYzN2UzMWYzYTYiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQG5hbm8uY29tIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNTg3ODIxOTQ2LCJleHAiOjE1ODc4MjI1NDYsImlhdCI6MTU4NzgyMTk0NiwiaXNzIjoiU2VuZEdyaWRLZXkiLCJhdWQiOiJTZW5kR3JpZEtleSJ9.yAgdVw3-QaPPrZQUrH_o0STfLAjDkJi8imo6ERrTn8nCfCuc4W5KsInzY5ihX1OE2qPyIf80xmFac3-WT4Iq8g";
       
        
        public const string userLogedInUsername = "admin@nano.com";
        public const string userLogedInPassword = "password";
        public const string userLogedInId = "83b05473-8607-4dd5-9c2e-6ef37e31f3a6";
        public const string userAnOtherId = "388de2bc-851d-4c95-8bf9-1939e52e44c8";
        public const string userLogedInPhotoId = "250457b8-db5b-4704-976c-ca50edbec4f1";
        public const string userAnOtherPhotoId = "e97fd389-fb3d-4ea2-929d-435f5e";


        public static readonly IEnumerable<User> Users = new List<User>()
        {
            new User
            {
                Id = "83b05473-8607-4dd5-9c2e-6ef37e31f3a6",
                DateOfBirth = DateTime.Now,
                LastActive = DateTime.Now,
                PasswordHash ="",
                UserName = "admin@nano.com",
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
                        Id = "0d47394e-672f-4db7-898c-bfd8f32e2af",
                        UserId = "83b05473-8607-4dd5-9c2e-6ef37e31f3a6",
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

        public static readonly IEnumerable<Role> Roles = new List<Role>()
        {
            new Role()
            {
                Id = "b3f1fe2b-dd16-4d09-9c99-50ed30de43e7",
                Name = "Admin"
            },
            new Role()
            {
                Id = "8a37ea52-4eda-47d3-8f67-4c818c9fca0c",
                Name = "User"
            }
        };

        public static readonly IList<string> RolesString = new List<string>()
        {
           "Admin","Blog"
        };

        public static readonly RoleEditDto roleEditDto = new RoleEditDto
        {
            RoleNames = new[] { "User" }
        };

        public static readonly Setting settingForUpload = new Setting()
        {
            CloudinaryCloudName = "12",
            CloudinaryAPIKey = "12",
            CloudinaryAPISecret = "12"
        };

        public static readonly UserForDetailedDto userForDetailedDto = new UserForDetailedDto()
        {
            Id = "83b05473-8607-4dd5-9c2e-6ef37e31f3a6",
            UserName = "admin@nano.com",
            Name = "Holloway Vasquez",
            PhoneNumber = "55",
            Address = "55",
            Gender = true,
            City = "55",
            Age = 15,
            LastActive = DateTime.Now,
            PhotoUrl = "qqq"
        };


        public static readonly UserForRegisterDto userForRegisterDto = new UserForRegisterDto()
        {
            UserName = "assasas@b545ma.com",
            Password = "password",
            Name = "کیوان",
            PhoneNumber = "15486523"
        };

        public static readonly UserForRegisterDto userForRegisterDto_Fail_Exist = new UserForRegisterDto()
        {
            UserName = "admin@nano.com",
            Password = "password",
            Name = "کیوان",
            PhoneNumber = "15486523"
        };

        public static readonly UserForRegisterDto userForRegisterDto_Fail_ModelState = new UserForRegisterDto()
        {
            UserName = string.Empty,
            Password = string.Empty,
            Name = string.Empty,
            PhoneNumber = string.Empty
        };

        public static readonly TokenRequestDto useForLoginDto_Success_password = new TokenRequestDto()
        {
            GrantType = "password",
            UserName = "admin@nano.com",
            Password = "password",
            IsRemember = true
        };
        public static readonly TokenRequestDto useForLoginDto_Success_refreshToken = new TokenRequestDto()
        {
            GrantType = "refresh_token",
            UserName = "admin@nano.com",
            RefreshToken = "1601c692e92541398a9ab6250426d6e7",
            IsRemember = true
        };
        public static readonly TokenRequestDto useForLoginDto_Fail_refreshToken = new TokenRequestDto()
        {
            GrantType = "refresh_token",
            UserName = "admin@nano.com",
            RefreshToken = "noRefreshToken",
            IsRemember = true
        };
        public static readonly TokenRequestDto useForLoginDto_Fail_password = new TokenRequestDto()
        {
            GrantType = "password",
            UserName = "00@000.com",
            Password = "password",
            IsRemember = true
        };


        public static readonly TokenRequestDto useForLoginDto_Fail_ModelState = new TokenRequestDto()
        {

            UserName = string.Empty,
            GrantType = string.Empty
        };

        public static readonly PhotoForProfileDto photoForProfileDto = new PhotoForProfileDto()
        {
            Url = "http://google.com",
            PublicId = "1"
        };

        public static readonly UserForUpdateDto userForUpdateDto = new UserForUpdateDto()
        {
            Name = "علی حسینی",
            PhoneNumber = "string",
            Address = "string",
            Gender = true,
            City = "string"
        };

        public static readonly UserForUpdateDto userForUpdateDto_Fail_ModelState = new UserForUpdateDto()
        {
            Name = string.Empty,
            PhoneNumber = string.Empty,
            Address = string.Empty,
            City =
                "لورم ایپسوم متن ساختگی با تولید سادگلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی درلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی درلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی دری نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی در."

        };

        public static readonly PasswordForChangeDto passwordForChangeDto = new PasswordForChangeDto()
        {
            OldPassword = "123789",
            NewPassword = "123789"
        };

        public static readonly PasswordForChangeDto passwordForChangeDto_Fail = new PasswordForChangeDto()
        {
            OldPassword = "123789654645",
            NewPassword = "123789"
        };

        public static readonly PasswordForChangeDto passwordForChangeDto_Fail_ModelState = new PasswordForChangeDto()
        {
            OldPassword = string.Empty,
            NewPassword = string.Empty
        };

        public static readonly UserForUpdateDto userForUpdateDto_Fail = new UserForUpdateDto()
        {
            Name = "kldlsdnf"
        };

        public static readonly PasswordForChangeDto passwordForChangeDto_Success = new PasswordForChangeDto()
        {
            OldPassword = It.IsAny<string>(),
            NewPassword = It.IsAny<string>()
        };



        public static readonly PhotoForReturnProfileDto PhotoForReturnProfileDto = new PhotoForReturnProfileDto()
        { };

        public static readonly FileUploadedDto fileUploadedDto_Success = new FileUploadedDto()
        {
            Status = true,
            LocalUploaded = true,
            Message = "با موفقیت در لوکال آپلود شد",
            PublicId = "0",
            Url = "wwwroot/Files/Pic/Profile/"
        };

        public static readonly FileUploadedDto fileUploadedDto_Fail_WrongFile = new FileUploadedDto()
        {
            Status = false,
            Message = "فایلی برای اپلود یافت نشد"
        };

    }
}