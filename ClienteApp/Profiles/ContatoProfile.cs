using AutoMapper;
using ClienteApp.Data.Dtos;
using ClienteApp.Models;

namespace ClienteApp.Profiles
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<CreateContatoDto, Contato>();
            CreateMap<Contato, ReadContatoDto>();
            CreateMap<UpdateContatoDto, Contato>();
        }
    }
}
