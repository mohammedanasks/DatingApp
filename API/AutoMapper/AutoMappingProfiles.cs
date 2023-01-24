using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.AutoMapper
{
    public class AutoMappingProfiles : Profile
    {

       public AutoMappingProfiles()
       {
        CreateMap<AppUser,MemberDto>()
        .ForMember(dest=>dest.PhotoUrl,opt=>opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url))
        .ForMember(dest=>dest.Age,opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
        CreateMap<Photo,PhotoDto>();
       }
        
    }
}