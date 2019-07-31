using ProjectVerity.Domain.Entities;
using SimpleVerityProject.IoC;
using SimpleVerityProject.Services.Interfaces;
using SimpleVerityProject.Web.Mappers;
using SimpleVerityProject.Web.Models;
using SimpleVerityProject.Web.Models.ModelsHelper;
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
               
        public ActionResult Index()
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            var mapper = autoMapperConfig.Configure().CreateMapper();

            var produtos = _produtoService.ListarTodos();

            DropListMovimentoViewModel model = new DropListMovimentoViewModel();

            var produtosViewModels = mapper.Map<List<ProdutoViewModel>>(produtos);

            foreach (var item in produtosViewModels)
            {
                model.ProdutosDisponiveis.Add(new SelectListItem
                {
                    Text = item.Descricao,
                    Value = item.Id.ToString()
                });
            }

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult BuscarCosif(int produtoId)
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            var mapper = autoMapperConfig.Configure().CreateMapper();

            var cosifs = _cosifService.BuscarPorProdutoId(produtoId);

            var cosifViewModel = mapper.Map<List<CosifViewModel>>(cosifs);

            return Json(cosifViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalvarMovimento(MovimentoViewModel movimentoViewModel)
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            var mapper = autoMapperConfig.Configure().CreateMapper();

            movimentoViewModel.Lancamento = _movimentoService.BuscarLancamentoPorMesAno(movimentoViewModel.MesDeReferencia, movimentoViewModel.AnoDeReferencia);

            var movimento = mapper.Map<Movimento>(movimentoViewModel);

            var cosifs = _movimentoService.Salvar(movimento);

            return View();
        }

        public ActionResult Relatorio()
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            var mapper = autoMapperConfig.Configure().CreateMapper();

            var movimentos = _movimentoService.BuscarTodos();

            var movimentosViewModel = mapper.Map<List<MovimentoViewModel>>(movimentos);

            return View(movimentosViewModel);
        }
    }
}