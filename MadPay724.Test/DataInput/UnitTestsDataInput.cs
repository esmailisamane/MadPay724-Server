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
        public static readonly string unToken = "";

        public static readonly string aToken =
            "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5NTc4Zjc2Ni01ZDQ0LTRhYmUtYTU1Ni1iMWIyYzI1N2Y3NGEiLCJ1bmlxdWVfbmFtZSI6InNlQGdtYWlsLmNvbSIsIm5iZiI6MTU4NzI5OTgxMiwiZXhwIjoxNTg3Mzg2MjEyLCJpYXQiOjE1ODcyOTk4MTJ9.Ym9ch5yZzv0qIB2fQj8476Z6EeIN3udUgs1GVOjFuOMdSY_TcDq5Lo5ZxmTtzNrvZA59mXeIHQO0fG-Q6ey9aA";



        public static readonly string userLogedInUsername = "se@gmail.com";
        public static readonly string userLogedInPassword = "123456";
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
            UserName = "g@gmail.com",
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
            UserName = "se@gmail.com",
            Password = "123456",
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
            OldPassword = "123456",
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