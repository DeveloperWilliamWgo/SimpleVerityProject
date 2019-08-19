using AutoMapper;
using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Web.Models;

namespace SimpleVerityProject.Web.Mappers
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoViewModel>();
                cfg.CreateMap<Produto, ProdutoModel>();

                cfg.CreateMap<Cosif, CosifModel>();
                cfg.CreateMap<Cosif, CosifViewModel>();

                cfg.CreateMap<Movimento, MovimentoModel>();
                cfg.CreateMap<Movimento, MovimentoViewModel>();

                cfg.AddProfile<AuthorMappingProfile>();
            });

            return config;
        }
    }
}