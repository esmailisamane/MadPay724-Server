﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MadPay724.Common.ErrorAndMesseage;
using MadPay724.Common.Helpers.Interface;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Common.Token;
using MadPay724.Data.Dtos.Site.Panel.Auth;
using MadPay724.Data.Dtos.Site.Panel.Users;
using MadPay724.Data.Models;
using MadPay724.Presentation.Routes.V1;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace MadPay724.Presentation.Controllers.Site.V1.Auth
{

    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = "v1_Site_Panel")]
    //[Route("api/v1/site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;
        private readonly IUtilities _utilities;
        private readonly UserManager<Data.Models.User> _userManager;
        //private readonly SignInManager<Data.Models.User> _signInManager;


        public AuthController(IUnitOfWork<MadpayDbContext> dbContext, IAuthService authService,
            IConfiguration config, IMapper mapper, ILogger<AuthController> logger, IUtilities utilities,
            UserManager<Data.Models.User> userManager)
        {
            _db = dbContext;
            _authService = authService;
            _config = config;
            _mapper = mapper;
            _logger = logger;
            _utilities = utilities;
            _userManager = userManager;
        }


        [HttpPost(ApiV1Routes.Auth.Register)]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCreate = new Data.Models.User
            {
                UserName = userForRegisterDto.UserName,
                Name = userForRegisterDto.Name,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Address = "",
                City = "",
                Gender = true,
                DateOfBirth = DateTime.Now,
                IsActive = true,
                Status = true,
            };

            var photoToCreate = new Photo
            {
                UserId = userToCreate.Id,
                Url = string.Format("{0}://{1}{2}/{3}",
                    Request.Scheme,
                    Request.Host.Value ?? "",
                    Request.PathBase.Value ?? "",
                    "wwwroot/Files/Pic/profilepic.png"), //"https://res.cloudinary.com/keyone2693/image/upload/v1561717720/768px-Circle-icons-profile.svg.png",
                Description = "Profile Pic",
                Alt = "Profile Pic",
                IsMain = true,
                PublicId = "0"
            };

            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

            if (result.Succeeded)
            {
                await _authService.AddUserPhotos(photoToCreate);

                var userForReturn = _mapper.Map<UserForDetailedDto>(userToCreate);

                _logger.LogInformation($"{userForRegisterDto.Name} - {userForRegisterDto.UserName} ثبت نام کرده است");

                return CreatedAtRoute("GetUser", new
                {
                    controller = "Users",
                    id = userToCreate.Id
                }, userForReturn);
            }
            else if (result.Errors.Any())
            {
                _logger.LogWarning(result.Errors.First().Description);
                return BadRequest(new returnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = result.Errors.First().Description
                });
            }
            else
            {
                return BadRequest(new returnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = "خطای نامشخص"
                });
            }


        }
        [HttpPost(ApiV1Routes.Auth.Login)]
        public async Task<IActionResult> Login(TokenRequestDto tokenRequestDto)
        {
            switch (tokenRequestDto.GrantType)
            {
                case "password":
                    var result = await _utilities.GenerateNewTokenAsync(tokenRequestDto);
                    if (result.status)
                    {
                        var userForReturn = _mapper.Map<UserForDetailedDto>(result.user);

                        return Ok(new LoginResponseDto
                        {
                            token = result.token,
                            refresh_token = result.refresh_token,
                            user = userForReturn
                        });
                    }
                    else
                    {
                        _logger.LogWarning($"{tokenRequestDto.UserName} درخواست لاگین ناموفق داشته است" + "---" + result.message);
                        return Unauthorized("1x111keyvanx11");
                    }
                case "refresh_token":
                    var res = await _utilities.RefreshAccessTokenAsync(tokenRequestDto);
                    if (res.status)
                    {
                        return Ok(res);
                    }
                    else
                    {
                        _logger.LogWarning($"{tokenRequestDto.UserName} درخواست لاگین ناموفق داشته است" + "---" + res.message);
                        return Unauthorized("0x000keyvanx00");
                    }
                default:
                    return Unauthorized("خطا در اعتبار سنجی دوباره");
            }
        }
    }
}