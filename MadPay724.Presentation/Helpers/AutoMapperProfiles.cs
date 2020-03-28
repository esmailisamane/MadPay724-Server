using AutoMapper;
using MadPay724.Common.Helpers;
using MadPay724.Data.Dtos.Site.Admin.BankCards;
using MadPay724.Data.Dtos.Site.Admin.Photos;
using MadPay724.Data.Dtos.Site.Admin.Users;
using MadPay724.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MadPay724.Presentation.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public  AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
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
            CreateMap<BankCard, BankcardForUserDetailedDto>();

        }


    }
}
