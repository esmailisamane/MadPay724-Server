using System;
using System.Collections.Generic;
using System.Text;
using MadPay724.Data.Dtos.Services;
using MadPay724.Data.Dtos.Site.Admin.Photos;
using MadPay724.Data.Dtos.Site.Admin.Users;
using MadPay724.Data.Models;
using Moq;

namespace MadPay724.Test.DataInput
{
    public static class UnitTestsDataInput
    {
        public static readonly string baseRouteV1 = "api/v1/";

        public static readonly string unToken = "";

        public static readonly string aToken =
            "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzYjY0YmRiYS01ZDE4LTQ3ZWYtOWYxNS03NTU2NTRhNDkyYTQiLCJ1bmlxdWVfbmFtZSI6InNAZ21haWwuY29tIiwibmJmIjoxNTg3NDgxNDU1LCJleHAiOjE1ODc1Njc4NTUsImlhdCI6MTU4NzQ4MTQ1NX0.ZgHRVGs3G56hSAHmMeJ0WpqbsaY3ga_c6DYPajgI2f9c0RjPbdDvRWqXo1FObdIFFHEM6Eoqe62VIXhHi2kczg";



        public static readonly string userLogedInUsername = "s@gmail.com";
        public static readonly string userLogedInPassword = "12345";
        public static readonly string userLogedInId = "9578f766-5d44-4abe-a556-b1b2c257f74a";
        public static readonly string userAnOtherId = "0d47394e-672f-4db7-898c-bfd8f32e2af7";
        public static readonly string userLogedInPhotoId = "ba09fde5-3754-4e94-908e-7d1db6fb4aa3";


        public static readonly IEnumerable<User> Users = new List<User>()
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
                UserName = "haysmathis@barkarama.com",
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

        public static readonly Setting settingForUpload = new Setting()
        {
            CloudinaryCloudName = "12",
            CloudinaryAPIKey = "12",
            CloudinaryAPISecret = "12"
        };

        public static readonly UserForDetailedDto userForDetailedDto = new UserForDetailedDto()
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


        public static readonly UserForRegisterDto userForRegisterDto = new UserForRegisterDto()
        {
            UserName = "gse@gmail.com",
            Password = "123789",
            Name = "soni",
            PhoneNumber = "0912552932"
        };

        public static readonly UserForRegisterDto userForRegisterDto_Fail_Exist = new UserForRegisterDto()
        {
            UserName = "se@gmail.com",
            Password = "123456",
            Name = "sara",
            PhoneNumber = "12345678"
        };

        public static readonly UserForRegisterDto userForRegisterDto_Fail_ModelState = new UserForRegisterDto()
        {
            UserName = string.Empty,
            Password = string.Empty,
            Name = string.Empty,
            PhoneNumber = string.Empty
        };

        public static readonly UserForLoginDto useForLoginDto_Success = new UserForLoginDto()
        {
            UserName = "s@gmail.com",
            Password = "12345",
            IsRemember = true
        };

        public static readonly UserForLoginDto useForLoginDto_Fail = new UserForLoginDto()
        {
            UserName = "00@000.com",
            Password = "0000",
            IsRemember = true
        };

        public static readonly UserForLoginDto useForLoginDto_Fail_ModelState = new UserForLoginDto()
        {
            UserName = string.Empty,
            Password = string.Empty
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
            OldPassword = "12345",
            NewPassword = "12345"
        };

        public static readonly PasswordForChangeDto passwordForChangeDto_Fail = new PasswordForChangeDto()
        {
            OldPassword = "123789654645",
            NewPassword = "12345"
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