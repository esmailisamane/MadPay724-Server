using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MadPay724.Common.ErrorAndMesseage;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Admin;
using MadPay724.Data.Dtos.Site.Admin.Users;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace MadPay724.Presentation.Controllers.Site.Admin
{   [Authorize]
    [ApiExplorerSettings(GroupName ="Site")]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IUnitOfWork<MadpayDbContext> dbContex, IAuthService authService,IConfiguration config, IMapper mapper, ILogger<AuthController> logger)
        {
            _db = dbContex;
            _authService = authService;
            _config = config;
            _mapper = mapper;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register (UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _db.UserRepository.UserExists(userForRegisterDto.UserName))
            {
                _logger.LogWarning($"{userForRegisterDto.UserName}میخواهد دوباره ثبت نام کند. ");
                return BadRequest(new returnMessage()
                {
                    status = false,
                    title = "خطا",
                    message ="نام کاربری وجود دارد",
                   

                });
            }
               
            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName,
                Name= userForRegisterDto.Name,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Address = "",
                City = "",
                DateOfBirth = DateTime.Now,
                Gender = true,
                IsActive = true,
                Status = true,
            };

            var photoToCreate = new Photo
            {
               UserId = userToCreate.Id,
               Url = string.Format("{0}://{1}{2}/{3}", Request.Scheme, Request.Host.Value, Request.PathBase.Value, "wwwroot/Files/Pic/profilepic.png"),
               Description="Profile Pic",
               Alt= "Profile Pic",
               IsMain= true,
               PublicId="0",
            };

            var createdUser = await _authService.Register(userToCreate, photoToCreate, userForRegisterDto.Password);
            _logger.LogInformation($"{userForRegisterDto.UserName} ثبت نام کرده است ");
            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> login(UserForLoginDto userForLoginDto)
        {   
            
            var userFromRepo = await _authService.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if (userFromRepo == null)
            {
                _logger.LogWarning($"{userForLoginDto.UserName} درخواست لاگین ناموفق داشته است");
                return Unauthorized("کاربری با این یوزر و پسورد وجود ندارد");
            }
              
                //return Unauthorized(new returnMessage()
                //{
                //    status = false,
                //    title = "خطا",
                //    message = "کاربری با این یوزر و پسورد وجود ندارد",


                //});
            var clamis = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clamis),
                Expires = userForLoginDto.IsRemember ? DateTime.Now.AddDays(1): DateTime.Now.AddHours(2),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDes);

            var user = _mapper.Map<UserForDetailedDto>(userFromRepo);

            _logger.LogInformation($"{userForLoginDto.UserName}لاگین کرده است ");
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
            
        }

       
    }
}