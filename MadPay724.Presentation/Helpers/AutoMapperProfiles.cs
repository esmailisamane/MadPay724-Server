﻿using AutoMapper;
using MadPay724.Common.Helpers.Helpers;
using MadPay724.Common.Helpers.MediaTypes;
using MadPay724.Data.Dtos.Common.ION;
using MadPay724.Data.Dtos.Site.Admin.BankCards;
using MadPay724.Data.Dtos.Site.Admin.Photos;
using MadPay724.Data.Dtos.Site.Admin.Users;
using MadPay724.Data.Models;
using System.Linq;

namespace MadPay724.Presentation.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public  AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
               .ForMember(dest => dest.Self, opt =>
                   opt.MapFrom(src =>
                   Link.To(nameof(Controllers.V1.Site.Admin.UsersController.GetUser), new { id = src.Id })))

               ;

            CreateMap<User, UserForDetailedDto>()
                .ForMember(des => des.PhotoUrl, opt=>
                    {
                        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                    })
               .ForMember (des => des.Age, opt =>
                    {
                        opt.MapFrom(src => src.DateOfBirth.ToAge());
                    });
            CreateMap<Photo, PhotoForUserDetailedDto>();
            CreateMap<PhotoForProfileDto, Photo>();
            CreateMap<Photo, PhotoForReturnProfileDto>();
            CreateMap<BankCard, BankcardForUserDetailedDto>();
            CreateMap<UserForUpdateDto, User>();

        }


    }
}
