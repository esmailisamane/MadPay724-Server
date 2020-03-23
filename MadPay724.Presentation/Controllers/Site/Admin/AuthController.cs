using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MadPay724.Common.ErrorAndMesseage;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Admin;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MadPay724.Presentation.Controllers.Site.Admin
{   [Authorize]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        public AuthController(IUnitOfWork<MadpayDbContext> dbContex, IAuthService authService,IConfiguration config)
        {
            _db = dbContex;
            _authService = authService;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register (UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _db.UserRepository.UserExists(userForRegisterDto.UserName))
            {
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

            var createdUser = await _authService.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _authService.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized(new returnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = "کاربری با این یوزر و پسورد وجود ندارد",


                });
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
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }


        [AllowAnonymous]
        [HttpGet("GetValue")]
        public async Task<IActionResult> GetValue()
        {
           
            return Ok(new returnMessage()
            {
                status = true,
                title = "اوکی",
                message = "نام کاربری وجود دارد",


            });
        }


        
        [HttpGet("GetValues")]
        public async Task<IActionResult> GetValues()
        {

            return Ok(new returnMessage()
            {
                status = true,
                title = "اوکی",
                message = "نام کاربری وجود دارد",


            });
        }
    }
}