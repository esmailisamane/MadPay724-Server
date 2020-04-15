using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MadPay724.Common.Helpers;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Admin.Photos;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MadPay724.Presentation.Controllers.Site.Admin
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "Site")]
    [Route("site/admin/{userId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfige;
        private readonly Cloudinary _cloudinary;
        public PhotosController(IUnitOfWork<MadpayDbContext> dbContext, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfige)
        {
            _db = dbContext;
            _mapper = mapper;
            _cloudinaryConfige = cloudinaryConfige;
            Account acc = new Account(
                          _cloudinaryConfige.Value.CloudName,
                          _cloudinaryConfige.Value.APIKey,
                          _cloudinaryConfige.Value.APISecret);
            _cloudinary = new Cloudinary(acc);


        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserPhoto(string userId,[FromForm] PhotoForProfileDto photoForProfileDto)
        {
            if(userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                return Unauthorized("شما اجازه تغییر تصویر این کاربر را ندارید");
            }
            var userFromRepo = await _db.UserRepository.GetByIdAsync(userId);
            var file = photoForProfileDto.File;
            var uploadResult = new ImageUploadResult();
            if(file.Length> 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(250).Height(250).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoForProfileDto.Url = uploadResult.Uri.ToString();
            photoForProfileDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForProfileDto);

            await _db.PhotoRepository.InsertAsync(photo);
            if(await _db.saveAsync())
            {
                return Ok();
            }
            else
            {
                return BadRequest("خطا در آپلود ! دوباره امتحان کنید.");
            }
           

        }


    }
}