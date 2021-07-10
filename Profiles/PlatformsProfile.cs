using AutoMapper;
using Comandos.Dtos;
using Comandos.Models;

namespace Comandos.Profiles {

    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<PlatformCreateDto, Platform>();
        }
    }

}