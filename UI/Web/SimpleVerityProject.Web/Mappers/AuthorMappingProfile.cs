using AutoMapper;
using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Web.Models;

namespace SimpleVerityProject.Web.Mappers
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Movimento, MovimentoViewModel>().ReverseMap();
        }
    }
}