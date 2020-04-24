using System;
using System.Collections.Generic;
using System.Text;
using MadPay724.Data.Dtos.Services;
using MadPay724.Data.Dtos.Site.Panel.Photos;
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
            "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI1OGIzYzBkZC03YWRlLTQzM2YtODUxYS04M2YyZjc5OTdjZGUiLCJ1bmlxdWVfbmFtZSI6InNlQGdtYWlsLmNvbSIsIm5iZiI6MTU4NzcwOTE1OCwiZXhwIjoxNTg3Nzk1NTU4LCJpYXQiOjE1ODc3MDkxNTh9.XxuJHAteL-hicTLNjcURNafSYGU8M_zLYD824atHKNJ-DFZuljF6iU-RFmRWrY5aidiWZJ8fEXeaOyF7Ap57kQ";


        public const string userLogedInUsername = "se@gmail.com";
        public const string userLogedInPassword = "e123456";
        public const string userLogedInId = "08dfeb06-2a29-4d53-976e-15093272d5c0";
        public const string userAnOtherId = "388de2bc-851d-4c95-8bf9-1939e52e44c8";
        public const string userLogedInPhotoId = "250457b8-db5b-4704-976c-ca50edbec4f1";
        public const string userAnOtherPhotoId = "e97fd389-fb3d-4ea2-929d-435f5e";


        public static readonly IEnumerable<User> Users = new List<User>()
        {
            new User
            {
                Id = "08dfeb06-2a29-4d53-976e-15093272d5c0",
                DateOfBirth = DateTime.Now,
                LastActive = DateTime.Now,
                PasswordHash ="",
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
                        Id = "250457b8-db5b-4704-976c-ca50edbec4f1",
                        UserId = "08dfeb06-2a29-4d53-976e-15093272d5c0",
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
            Id = "58b3c0dd-7ade-433f-851a-83f2f7997cde",
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
            UserName = "asasas@b545ma.com",
            Password = "password",
            Name = "کیوان",
            PhoneNumber = "15486523"
        };

        public static readonly UserForRegisterDto userForRegisterDto_Fail_Exist = new UserForRegisterDto()
        {
            UserName = "se@gmail.com",
            Password = "e123456",
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

        public static readonly UserForLoginDto useForLoginDto_Success = new UserForLoginDto()
        {
            UserName = "se@gmail.com",
            Password = "e123456",
            IsRemember = true
        };

        public static readonly UserForLoginDto useForLoginDto_Fail = new UserForLoginDto()
        {
            UserName = "00@000.com",
            Password = "password",
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
            OldPassword = "123789",
            NewPassword = "123789"
        };

        public static readonly PasswordForChangeDto passwordForChangeDto_Fail = new PasswordForChangeDto()
        {
            OldPassword = "1237891",
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