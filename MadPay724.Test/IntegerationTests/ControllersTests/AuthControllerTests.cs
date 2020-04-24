﻿using MadPay724.Common.ErrorAndMesseage;
using MadPay724.Presentation;
using MadPay724.Test.DataInput;
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
        private readonly HttpClient _client;

        public AuthControllerTests(TestClientProvider<Startup> testClientProvider)
        {
            _client = testClientProvider.Client;
        }

        #region loginTests
        [Fact]
        public async Task Login_Success_UserLogin()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = UnitTestsDataInput.baseRouteV1 + "site/panel/auth/login";
            var model = UnitTestsDataInput.useForLoginDto_Success;
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
            var request = UnitTestsDataInput.baseRouteV1 + "site/panel/auth/login";
            var model = UnitTestsDataInput.useForLoginDto_Fail;
            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request, ContentHelper.GetStringContent(model));
            var actual = await response.Content.ReadAsAsync<string>();
            //Assert-------------------------------------------------------------------------------------------------------------------------------

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("کاربری با این یوزر و پس وجود ندارد", actual);
        }
        [Fact]
        public async Task Login_Fail_ModelStateError()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = new
            {
                Url = UnitTestsDataInput.baseRouteV1 + "site/panel/auth/login",
                Body = UnitTestsDataInput.useForLoginDto_Fail_ModelState
            };

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));


            //Assert-------------------------------------------------------------------------------------------------------------------------------


            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);



            //Assert


        }
        #endregion

        #region registerTests
        [Fact]
        public async Task Register_Success_UserRegister()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = UnitTestsDataInput.baseRouteV1 + "site/panel/auth/register";
            var model = UnitTestsDataInput.userForRegisterDto;
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
            var request = UnitTestsDataInput.baseRouteV1 + "site/panel/auth/register";
            var model = UnitTestsDataInput.userForRegisterDto_Fail_Exist;
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
            //Assert.Equal(expected.message, actual.message);


        }
        [Fact]
        public async Task Register_Fail_ModelStateError()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            var request = new
            {
                Url = UnitTestsDataInput.baseRouteV1 + "site/panel/auth/register",
                Body = UnitTestsDataInput.userForRegisterDto_Fail_ModelState
            };

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));


            //Assert-------------------------------------------------------------------------------------------------------------------------------


            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);



            //Assert


        }
        #endregion

    }
}