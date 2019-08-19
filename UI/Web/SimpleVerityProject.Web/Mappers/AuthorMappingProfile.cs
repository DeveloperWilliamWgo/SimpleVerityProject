using AutoMapper;
using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Web.Models;

namespace SimpleVerityProject.Web.Mappers
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Movimento, MovimentoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Cosif, CosifViewModel>().ReverseMap();

            CreateMap<Movimento, MovimentoModel>().ReverseMap();
            CreateMap<Produto, ProdutoModel>().ReverseMap();
            CreateMap<Cosif, CosifModel>().ReverseMap();
        }
    }
}