using System;
using AutoMapper;
using agos_api.Models.Users;
using agos_api.Models.Studying;

namespace agos_api.Models.Base
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DevUser, DevUser>();
            // CreateMap<Speciality, DisciplineSpecialityViewModel>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}