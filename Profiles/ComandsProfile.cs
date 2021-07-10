using AutoMapper;
using Comandos.Dtos;
using Comandos.Models;

namespace Comandos.Profiles {

    public class CommadsProfile : Profile
    {
        public CommadsProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }

}