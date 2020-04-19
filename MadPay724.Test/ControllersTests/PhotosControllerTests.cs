using MadPay724.Data.Dtos.Site.Admin.Photos;
using MadPay724.Presentation;
using MadPay724.Test.Providers;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MadPay724.Test.ControllersTests
{
    public class PhotosControllerTests : IClassFixture<TestClientProvider<Startup>>
    {
        private HttpClient _client;
        private readonly string _UnToken;
        private readonly string _AToken;
        public PhotosControllerTests(TestClientProvider<Startup> testClientProvider)
        {
            _client = testClientProvider.Client;
            _UnToken = "";
            //0d47394e-672f-4db7-898c-bfd8f32e2af7
            //haysmathis@barkarama.com
            //123789
            _AToken = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5NTc4Zjc2Ni01ZDQ0LTRhYmUtYTU1Ni1iMWIyYzI1N2Y3NGEiLCJ1bmlxdWVfbmFtZSI6InNlQGdtYWlsLmNvbSIsIm5iZiI6MTU4NzI5OTgxMiwiZXhwIjoxNTg3Mzg2MjEyLCJpYXQiOjE1ODcyOTk4MTJ9.Ym9ch5yZzv0qIB2fQj8476Z6EeIN3udUgs1GVOjFuOMdSY_TcDq5Lo5ZxmTtzNrvZA59mXeIHQO0fG-Q6ey9aA";
        }

        #region GetPhotoTests
        [Fact]
        public async Task GetPhoto_Can_Himself()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimselfId = "9578f766-5d44-4abe-a556-b1b2c257f74a";
            string userPhotoId = "ba09fde5-3754-4e94-908e-7d1db6fb4aa3";
            var request = "/site/admin/users/" + userHimselfId + "/photos/" + userPhotoId;

            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.GetAsync(request);

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task GetPhoto_Cant_AnOtherUser()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimselfId = "9578f766-5d44-4abe-a556-b1b2c257f74e";
            string userPhotoId = "ba09fde5-3754-4e94-908e-7d1db6fb4aa3";
            var request = "/site/admin/users/" + userHimselfId + "/photos/" + userPhotoId;

            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.GetAsync(request);

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        #endregion



        #region ChangeUserPhotoTests
        [Fact]
        public async Task ChangeUserPhoto_Can_Himself()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimselfId = "9578f766-5d44-4abe-a556-b1b2c257f74a";
            var fileMock = new Mock<IFormFile>();
            var fileName = "9578f766-5d44-4abe-a556-b1b2c257f74a.jpg";

            Bitmap image = new Bitmap(50, 50);
            Graphics imageData = Graphics.FromImage(image);
            imageData.DrawLine(new Pen(Color.Red), 0, 0, 50, 50);
            MemoryStream memoryStream = new MemoryStream();
            byte[] bitmapData;
            using (memoryStream)
            {
                image.Save(memoryStream, ImageFormat.Bmp);
                bitmapData = memoryStream.ToArray();
            }

            var ms = new MemoryStream(bitmapData);
            var writer = new StreamWriter(ms);
            writer.Flush();
            ms.Position = 0;

            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            byte[] data;
            using (var br = new BinaryReader(fileMock.Object.OpenReadStream()))
                data = br.ReadBytes((int)fileMock.Object.OpenReadStream().Length);

            ByteArrayContent bytes = new ByteArrayContent(data);


            MultipartFormDataContent multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes, "File", fileMock.Object.FileName);

            var request = new
            {
                Url = "/site/admin/users/" + userHimselfId + "/photos",
                Body = new PhotoForProfileDto
                {
                    Url = "http://google.com",
                    PublicId = "1"
                }
            };

            multiContent.Add(ContentHelper.GetStringContent(request.Body));

            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request.Url, multiContent);

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task ChangeUserPhoto_Cant_WorngFile()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string userHimselfId = "9578f766-5d44-4abe-a556-b1b2c257f74a";

            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")),
                0, 0, "Data", "3b64bdba-5d18-47ef-9f15-755654a492a4.png");

            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
                data = br.ReadBytes((int)file.OpenReadStream().Length);

            ByteArrayContent bytes = new ByteArrayContent(data);
            MultipartFormDataContent multiContent = new MultipartFormDataContent();
            multiContent.Add(bytes, "File", file.FileName);

            var request = new
            {
                Url = "/site/admin/users/" + userHimselfId + "/photos",
                Body = new PhotoForProfileDto
                {
                    Url = "http://google.com",
                    PublicId = "1"
                }
            };

            multiContent.Add(ContentHelper.GetStringContent(request.Body));

            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request.Url, multiContent);

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task ChangeUserPhoto_Cant_AnOtherUser()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            string anOtherUserId = "c5ba73d4-d9d8-4e2d-9fe3-b328b8f7f84b";
            var request = new
            {
                Url = "/site/admin/users/" + anOtherUserId + "/photos",
                Body = new PhotoForProfileDto
                {
                    Url = "http://google.com",
                    PublicId = "1"


                }
            };
            _client.DefaultRequestHeaders.Authorization
           = new AuthenticationHeaderValue("Bearer", _AToken);

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        #endregion

    }
}
