using System;
using AutoMapper;
using agos_api.Models.Users;

namespace agos_api.Models.Base
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<devUser, devUser>();
        }
    }
}