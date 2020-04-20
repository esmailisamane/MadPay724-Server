
using MadPay724.Common.ErrorAndMesseage;
using MadPay724.Data.Dtos.Site.Admin.Users;
using MadPay724.Presentation;
using MadPay724.Test.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MadPay724.Test.ControllersTests
{
 public   class UsersControllerTests:IClassFixture<TestClientProvider<Startup>>
    {
        private HttpClient _client;
        private readonly string _UnToken;
        private readonly string _AToken;
        public UsersControllerTests(TestClientProvider<Startup> testClientProvider)
        {
            _client = testClientProvider.Client;
            _UnToken = "";
            _AToken = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzYjY0YmRiYS01ZDE4LTQ3ZWYtOWYxNS03NTU2NTRhNDkyYTQiLCJ1bmlxdWVfbmFtZSI6InNAZ21haWwuY29tIiwibmJmIjoxNTg3MjgxOTYwLCJleHAiOjE1ODczNjgzNjAsImlhdCI6MTU4NzI4MTk2MH0.AY9mxbh7k4-GxV9IBBAgGBDZMOT5vkoCI3RbR2ECHnxo_uyZra-3l-1t9FRqQKXLljG--qZlbeYPzmlSnP9_hw";
        }

        #region GetUserTests
        [Fact]
        public async Task GetUser_Success_GetUserHimself()
        {
            // Arrange------------------------------------------------------------------------------------------------------------------------------
            string anOtherUserId = "0d47394e-672f-4db7-898c-bfd8f32e2af7";
            var request = "/site/admin/Users/" + anOtherUserId;

            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.GetAsync(request);

            //Assert------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        [Fact]
        public async Task GetUser_Fail_GetAnOtherUser()
        {
            // Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimSelfId = "3b64bdba-5d18-47ef-9f15-755654a492a4";
            var request = "/site/admin/Users/" + userHimSelfId;
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.GetAsync(request);

            //Assert------------------------------------------------------------------------------------------------------------------------------
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region UpdateUserTests
        [Fact]
        public async Task UpdateUser_Success_UpdateUserHimself()
        {
            // Arrange------------------------------------------------------------------------------------------------------------------------------
            string anOtherUserId = "c5ba73d4-d9d8-4e2d-9fe3-b328b8f7f84b";
            var request = new
            {
                Url = "/site/admin/Users/" + anOtherUserId,
                Body = new
                {
                    Name = "علی حسینی",
                    PhoneNumber = "string",
                    Address = "string",
                    Gender = true,
                    City = "string"
                }
            };
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            //Assert------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        [Fact]
        public async Task UpdateUser_Fail_UpdateAnOtherUser()
        {
            // Arrange------------------------------------------------------------------------------------------------------------------------------
            string anOtherUserId = "3b64bdba-5d18-47ef-9f15-755654a492a4";
            var request = new
            {
                Url = "/site/admin/Users/" + anOtherUserId,
                Body = new
                {
                    Name = "علی حسینی",
                    PhoneNumber = "string",
                    Address = "string",
                    Gender = true,
                    City = "string"
                }
            };
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            //Assert------------------------------------------------------------------------------------------------------------------------------
            response.EnsureSuccessStatusCode();
            // response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task UpdateUser_Fail_ModelStateError()
        {
            // Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimselfId = "3b64bdba-5d18-47ef-9f15-755654a492a4";
            var request = new
            {
                Url = "/site/admin/Users/" + userHimselfId,
                Body = new UserForUpdateDto
                {
                    Name = string.Empty,
                    PhoneNumber = string.Empty,
                    Address = string.Empty,
                    City = "لورم ایپسوم متن ساختگی با تولید سادگلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی درلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی درلورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی دری نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه مجله در ستون و سطر آنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد کتابهای زیادی در."
                }
            };
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            var controller = new ModelStateControllerTests();


            //Act------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            controller.ValidateModelState(request.Body);
            var modelState = controller.ModelState;

            //Assert------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.False(modelState.IsValid);
            Assert.Equal(4, modelState.Keys.Count());
            Assert.True(modelState.Keys.Contains("Name") && modelState.Keys.Contains("PhoneNumber")
                && modelState.Keys.Contains("Address") && modelState.Keys.Contains("City"));

        }
        #endregion

        #region ChangeUserPasswordTests
        [Fact]
        public async Task ChangeUserPassword_Success_Himself()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimselfId = "3b64bdba-5d18-47ef-9f15-755654a492a4";
            var request = new
            {
                Url = "/site/admin/Users/ChangeUserPassword/" + userHimselfId,
                Body = new PasswordForChangeDto
                {
                    OldPassword = "12345",
                    NewPassword = "12345"
                }
            };
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Fact]
        public async Task ChangeUserPassword_Fail_AnOtherUser()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string anOtherUserId = "c5ba73d4-d9d8-4e2d-9fe3-b328b8f7f84b";
            var request = new
            {
                Url = "/site/admin/Users/ChangeUserPassword/" + anOtherUserId,
                Body = new PasswordForChangeDto
                {
                    OldPassword = "12345",
                    NewPassword = "12345"
                }
            };
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task ChangeUserPassword_Fail_Himself_WrongOldPassword()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimselfId = "3b64bdba-5d18-47ef-9f15-755654a492a4";
            var request = new
            {
                Url = "/site/admin/Users/ChangeUserPassword/" + userHimselfId,
                Body = new PasswordForChangeDto
                {
                    OldPassword = "12345678",
                    NewPassword = "12345"
                }
            };
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            var valueObj = JsonConvert.DeserializeObject<returnMessage>(value);

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(valueObj.status);
            Assert.Equal("پسورد قبلی اشتباه می باشد", valueObj.message);


        }
        [Fact]
        public async Task ChangeUserPassword_Fail_ModelStateError()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimselfId = "c5ba73d4-d9d8-4e2d-9fe3-b328b8f7f84b";
            var request = new
            {
                Url = "/site/admin/Users/ChangeUserPassword/" + userHimselfId,
                Body = new PasswordForChangeDto
                {
                    OldPassword = string.Empty,
                    NewPassword = string.Empty
                }
            };
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            var controller = new ModelStateControllerTests();


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            controller.ValidateModelState(request.Body);
            var modelState = controller.ModelState;

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.False(modelState.IsValid);
            Assert.Equal(2, modelState.Keys.Count());
            Assert.True(modelState.Keys.Contains("OldPassword") && modelState.Keys.Contains("NewPassword"));

        }
        #endregion
    }
}