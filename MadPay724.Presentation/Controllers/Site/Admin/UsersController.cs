using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Admin.Users;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MadPay724.Presentation.Controllers.Site.Admin
{

    [ApiExplorerSettings(GroupName = "Site")]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IMapper  _mapper;

        public UsersController(IUnitOfWork<MadpayDbContext> dbContex, IMapper mapper)
        {
            _db = dbContex;
            _mapper = mapper;


        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _db.UserRepository.GetAllAsync();

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _db.UserRepository.GetByIdAsync(id);
            var userToReturn = _mapper.Map<IEnumerable<UserForDetailedDto>>(user);
            return Ok(userToReturn);
        }
    }
}