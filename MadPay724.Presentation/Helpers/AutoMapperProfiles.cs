using AutoMapper;
using MadPay724.Common.Helpers.Helpers;
using MadPay724.Data.Dtos.Site.Panel.BankCards;
using MadPay724.Data.Dtos.Site.Panel.Photos;
using MadPay724.Data.Dtos.Site.Panel.Users;
using MadPay724.Data.Models;
using System.Linq;

namespace MadPay724.Presentation.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            //    .ForMember(dest => dest.Self, opt =>
            //        opt.MapFrom(src => 
            //        Link.To(nameof(Controllers.Site.V1.User.UsersController.GetUser),new { id= src.Id})))
            //    


            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(src => src.DateOfBirth.ToAge());
                });
            CreateMap<Photo, PhotoForUserDetailedDto>();
            CreateMap<PhotoForProfileDto, Photo>();
            CreateMap<Photo, PhotoForReturnProfileDto>();
            CreateMap<BankCard, BankcardForUserDetailedDto>();
            CreateMap<UserForUpdateDto, User>();

            //CreateMap<TokenResponseDto, LoginResponseDto>();
        }
    }
}