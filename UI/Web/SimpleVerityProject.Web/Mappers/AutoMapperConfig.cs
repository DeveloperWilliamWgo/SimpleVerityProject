using AutoMapper;
using ProjectVerity.Domain.Entities;
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
                cfg.AddProfile<AuthorMappingProfile>();
            });

            return config;
        }
    }
}