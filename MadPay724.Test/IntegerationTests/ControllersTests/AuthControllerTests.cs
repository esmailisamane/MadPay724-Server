using MadPay724.Common.ErrorAndMesseage;
using MadPay724.Data.Dtos.Site.Admin.Users;
using MadPay724.Presentation;
using MadPay724.Test.IntegerationTests.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MadPay724.Test.IntegerationTests.ControllersTests
{
    public class AuthControllerTests : IClassFixture<TestClientProvider<Startup>>
    {
        private HttpClient _client;
        private readonly string _UnToken;
        private readonly string _AToken;
        public AuthControllerTests(TestClientProvider<Startup> testClientProvider)
        {
            _client = testClientProvider.Client;
            _UnToken = "";
            //0d47394e-672f-4db7-898c-bfd8f32e2af7
            //haysmathis@barkarama.com
            //123789
            _AToken = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5NTc4Zjc2Ni01ZDQ0LTRhYmUtYTU1Ni1iMWIyYzI1N2Y3NGEiLCJ1bmlxdWVfbmFtZSI6InNlQGdtYWlsLmNvbSIsIm5iZiI6MTU4NzI5OTgxMiwiZXhwIjoxNTg3Mzg2MjEyLCJpYXQiOjE1ODcyOTk4MTJ9.Ym9ch5yZzv0qIB2fQj8476Z6EeIN3udUgs1GVOjFuOMdSY_TcDq5Lo5ZxmTtzNrvZA59mXeIHQO0fG-Q6ey9a";
        }
        #region loginTests
        [Fact]
        public async Task Login_Success_UserLogin()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = "/site/admin/auth/login";
            var model = new UserForLoginDto()
            {
                UserName = "se@gmail.com",
                Password = "123456",
                IsRemember = true
            };
            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request, ContentHelper.GetStringContent(model));

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Login_Fail_UserLogin()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = "/site/admin/auth/login";
            var model = new UserForLoginDto()
            {
                UserName = "00@000.com",
                Password = "0000",
                IsRemember = true
            };
            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request, ContentHelper.GetStringContent(model));
            var actual = await response.Content.ReadAsAsync<string>();
            //Assert-------------------------------------------------------------------------------------------------------------------------------

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("کاربری با این یوزر و پسورد وجود ندارد", actual);
        }
        [Fact]
        public async Task Login_Fail_ModelStateError()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = new
            {
                Url = "/site/admin/auth/login",
                Body = new UserForLoginDto
                {
                    UserName = string.Empty,
                    Password = string.Empty
                }
            };
            var controller = new ModelStateControllerTests();
            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            controller.ValidateModelState(request.Body);
            var modelState = controller.ModelState;
            //Assert-------------------------------------------------------------------------------------------------------------------------------


            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.False(modelState.IsValid);
            Assert.Equal(2, modelState.Keys.Count());
            Assert.True(modelState.Keys.Contains("UserName") && modelState.Keys.Contains("Password"));

            //Assert


        }
        #endregion

        #region registerTests
        [Fact]
        public async Task Register_Success_UserRegister()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = "/site/admin/auth/register";
            var model = new UserForRegisterDto()
            {
                UserName = "asasasasas@barkarama.com",
                Password = "123789",
                Name = "کیوان",
                PhoneNumber = "15486523"
            };
            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request, ContentHelper.GetStringContent(model));

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task Register_Fail_UserExist()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = "/site/admin/auth/register";
            var model = new UserForRegisterDto()
            {
                UserName = "haysmathis@barkarama.com",
                Password = "123789",
                Name = "کیوان",
                PhoneNumber = "15486523"
            };
            var expected = new returnMessage()
            {
                status = false,
                title = "خطا",
                message = "نام کاربری وجود دارد"
            };
            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request, ContentHelper.GetStringContent(model));
            var actual = await response.Content.ReadAsAsync<returnMessage>();
            //Assert-------------------------------------------------------------------------------------------------------------------------------

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.IsType<returnMessage>(actual);

            Assert.False(expected.status);
            Assert.Equal(expected.title, actual.title);
            Assert.Equal(expected.message, actual.message);


        }
        [Fact]
        public async Task Register_Fail_ModelStateError()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = new
            {
                Url = "/site/admin/auth/register",
                Body = new UserForRegisterDto
                {
                    UserName = string.Empty,
                    Password = string.Empty,
                    Name = string.Empty,
                    PhoneNumber = string.Empty
                }
            };
            var controller = new ModelStateControllerTests();
            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            controller.ValidateModelState(request.Body);
            var modelState = controller.ModelState;
            //Assert-------------------------------------------------------------------------------------------------------------------------------


            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.False(modelState.IsValid);
            Assert.Equal(4, modelState.Keys.Count());
            Assert.True(modelState.Keys.Contains("UserName") && modelState.Keys.Contains("Password")
                        && modelState.Keys.Contains("Name") && modelState.Keys.Contains("PhoneNumber"));

            //Assert


        }
        #endregion

    }
}
