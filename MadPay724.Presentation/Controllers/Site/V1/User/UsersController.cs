﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MadPay724.Common.ErrorAndMesseage;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Panel.Users;
using MadPay724.Presentation.Helpers.Filters;
using MadPay724.Presentation.Routes.V1;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadPay724.Presentation.Controllers.Site.V1.User
{
    [ApiExplorerSettings(GroupName = "v1_Site_Panel")]
    //[Route("api/v1/site/admin/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;


        public UsersController(IUnitOfWork<MadpayDbContext> dbContext, IMapper mapper,
            IUserService userService, ILogger<UsersController> logger)
        {
            _db = dbContext;
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        [Authorize(Policy = "AccessProfile")]
        [HttpGet(ApiV1Routes.Users.GetUser, Name = "GetUser")]
        [ServiceFilter(typeof(UserCkeckIdFilter))]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _db.UserRepository.GetManyAsync(p => p.Id == id, null, "Photos");
            var userToReturn = _mapper.Map<UserForDetailedDto>(user.SingleOrDefault());
            return Ok(userToReturn);
        }

        [Authorize(Policy = "AccessProfile")]
        [HttpPut(ApiV1Routes.Users.UpdateUser)]
        [ServiceFilter(typeof(UserCkeckIdFilter))]
        public async Task<IActionResult> UpdateUser(string id, UserForUpdateDto userForUpdateDto)
        {
            var userFromRepo = await _db.UserRepository.GetByIdAsync(id);

            _mapper.Map(userForUpdateDto, userFromRepo);
            _db.UserRepository.Update(userFromRepo);

            if (await _db.SaveAsync())
            {
                return NoContent();
            }
            else
            {
                _logger.LogError($"کاربر   {userForUpdateDto.Name} اپدیت نشد");

                return BadRequest(new returnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = $"ویرایش برای کاربر {userForUpdateDto.Name} انجام نشد."
                });
            }


        }

        [Authorize(Policy = "AccessProfile")]
        [HttpPut(ApiV1Routes.Users.ChangeUserPassword)]
        [ServiceFilter(typeof(UserCkeckIdFilter))]
        public async Task<IActionResult> ChangeUserPassword(string id, PasswordForChangeDto passwordForChangeDto)
        {
            var userFromRepo = await _userService.GetUserForPassChange(id, passwordForChangeDto.OldPassword);

            if (userFromRepo == null)
                return BadRequest(new returnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = "پسورد قبلی اشتباه میباشد"
                });

            if (await _userService.UpdateUserPass(userFromRepo, passwordForChangeDto.NewPassword))
            {
                return NoContent();
            }
            else
            {

                return BadRequest(new returnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = "ویرایش پسورد کاربرانجام نشد."
                });
            }
        }

        //[Route("GetProfileUser/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> GetProfileUser(string id)
        //{
        //    if (User.FindFirst(ClaimTypes.NameIdentifier).Value == id)
        //    {
        //        var user = await _db.UserRepository.GetManyAsync(p => p.Id == id, null, "Photos");
        //        var userToReturn = _mapper.Map<UserForDetailedDto>(user.SingleOrDefault());
        //        return Ok(userToReturn);
        //    }
        //    else
        //    {
        //        return Unauthorized("شما به این اطلاعات دسترسی ندارید");
        //    }
        //}
    }
}