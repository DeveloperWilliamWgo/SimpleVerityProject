using ProjectVerity.Services;
using SimpleInjector;
using SimpleVerityProject.Data;
using SimpleVerityProject.Data.Repositories;
using SimpleVerityProject.Data.Repositories.Base;
using SimpleVerityProject.Services.Interfaces;
using SimpleVerityProject.Services.Services;

namespace SimpleVerityProject.IoC
{
    public class IoCContainer
    {
        private readonly Container _container;

        public IoCContainer()
        {
            _container = new Container();

            _container.Register<IMovimentoRepository, MovimentoRepository>();
            _container.Register<IProdutoRepository, ProdutoRepository>();
            _container.Register<ICosifRepository, CosifRepository>();

            _container.Register<IMovimentoService, MovimentoService>();
            _container.Register<IProdutoService, ProdutoService>();
            _container.Register<ICosifService, CosifService>();
        }

        public Container GetContainer()
        {
            return _container;
        }
    }
}
