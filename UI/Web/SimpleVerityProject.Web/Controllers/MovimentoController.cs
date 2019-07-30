using ProjectVerity.Domain.Entities;
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

        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Movimento
        public ActionResult BuscarProdutos()
        {            
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            var mapper = autoMapperConfig.Configure().CreateMapper();

            var produtos = _produtoService.ListarTodos();
                    
            var viewModels = mapper.Map<List<ProdutoViewModel>>(produtos);

            var selectListItem = new List<SelectListItem>();

            foreach (var item in viewModels)
            {
                selectListItem.Add(new SelectListItem() { Text = item.Descricao, Value = item.ProdutoId.ToString() });
            }

            //ViewBag.Produtos = selectListItem;

            return Json(selectListItem, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult BuscarCosif(int codProduto)
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            var mapper = autoMapperConfig.Configure().CreateMapper();

            var cosifs = _cosifService.BuscarPorProdutoId(codProduto);

            var selectListItem = new List<SelectListItem>();

            foreach (var item in cosifs)
            {
                selectListItem.Add(new SelectListItem() { Text = item.Classificacao, Value = item.Id.ToString() });
            }

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

            return View(Index());
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