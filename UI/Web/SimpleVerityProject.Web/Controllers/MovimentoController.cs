using SimpleVerityProject.IoC;
using SimpleVerityProject.Services.Interfaces;
using SimpleVerityProject.Web.Mappers;
using SimpleVerityProject.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Controllers
{
    public class MovimentoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICosifService _cosifService;
        private readonly IMovimentoService _movimentoService;

        public MovimentoController()
        {
            var container = new IoCContainer().GetContainer();

            _movimentoService = container.GetInstance<IMovimentoService>();
            _produtoService = container.GetInstance<IProdutoService>();
            _cosifService = container.GetInstance<ICosifService>();
        }

        // GET: Movimento
        public ActionResult Index()
        {
            var produtos = _produtoService.ListarTodos();

            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();

            var mapper = autoMapperConfig.Configure().CreateMapper();

            var model = mapper.Map<List<ProdutoViewModel>>(produtos);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}