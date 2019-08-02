using ProjectVerity.Domain.Entities;
using SimpleVerityProject.IoC;
using SimpleVerityProject.Services.Interfaces;
using SimpleVerityProject.Web.Adapter;
using SimpleVerityProject.Web.Mappers;
using SimpleVerityProject.Web.Models;
using SimpleVerityProject.Web.Models.ModelsHelper;
using System;
using System.Collections.Generic;
using System.Json;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        [HttpPost]
        public ActionResult SalvarMovimento([Bind(Include = "MesDeReferencia,AnoDeReferencia,Lancamento,Valor,Descricao,DataCriacao,Usuario,Cosifs,CosifId,ProdutoId,ProdutosDisponiveis,CosifsDisponiveis")] MovimentoViewModel movimentoView)
        {
            movimentoView.Lancamento = _movimentoService.BuscarLancamentoPorMesAno(movimentoView.MesDeReferencia, movimentoView.AnoDeReferencia);

            var movimento = MovimentoAdapter.ViewModelToModel(movimentoView);

            var salvo = _movimentoService.Salvar(movimento);

            return Json( new { Resultado = salvo }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarMovimento()
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            var mapper = autoMapperConfig.Configure().CreateMapper();

            var movimentos = _movimentoService.BuscarTodos();

            var movimentosViewModel = mapper.Map<List<MovimentoViewModel>>(movimentos);

            return Json(movimentosViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}