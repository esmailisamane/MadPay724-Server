using System;
using System.Collections.Generic;
using System.Text;
using MadPay724.Data.Dtos.Site.Admin.Photos;
using MadPay724.Data.Dtos.Site.Admin.Users;
using Moq;

namespace MadPay724.Test.DataInput
{
    public static class UnitTestsDataInput
    {
        public static readonly string unToken = "";
        public static readonly string aToken = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5NTc4Zjc2Ni01ZDQ0LTRhYmUtYTU1Ni1iMWIyYzI1N2Y3NGEiLCJ1bmlxdWVfbmFtZSI6InNlQGdtYWlsLmNvbSIsIm5iZiI6MTU4NzI5OTgxMiwiZXhwIjoxNTg3Mzg2MjEyLCJpYXQiOjE1ODcyOTk4MTJ9.Ym9ch5yZzv0qIB2fQj8476Z6EeIN3udUgs1GVOjFuOMdSY_TcDq5Lo5ZxmTtzNrvZA59mXeIHQO0fG-Q6ey9aA";


        public static readonly string userLogedInUsername = "se@gmail.com";
        public static readonly string userLogedInPassword = "123456";
        public static readonly string userLogedInId = "9578f766-5d44-4abe-a556-b1b2c257f74a";
        public static readonly string userAnOtherId = "0d47394e-672f-4db7-898c-bfd8f32e2af7";
        public static readonly string userLogedInPhotoId = "ba09fde5-3754-4e94-908e-7d1db6fb4aa3";

        public static readonly UserForRegisterDto userForRegisterDto = new UserForRegisterDto()
        {
            UserName = "asasa78sasas@barkarama.com",
            Password = "123789",
            Name = "کیوان",
            PhoneNumber = "15486523"
        };
        public static readonly UserForRegisterDto userForRegisterDto_Fail_Exist = new UserForRegisterDto()
        {
            UserName = "haysmathis@barkarama.com",
            Password = "123789",
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
            UserName = "haysmathis@barkarama.com",
            Password = "123789",
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
            City = "لورم ایپسوم متن ساختگی با تولید سادگلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی درلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی درلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی دری نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی در."

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
    }
}
