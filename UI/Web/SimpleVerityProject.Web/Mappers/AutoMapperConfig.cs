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
                cfg.CreateMap<Movimento, MovimentoViewModel>();
                cfg.AddProfile<AuthorMappingProfile>();
            });

            return config;
        }
    }
}