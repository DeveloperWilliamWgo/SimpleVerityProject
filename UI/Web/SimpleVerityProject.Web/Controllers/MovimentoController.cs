using NLog;
using SimpleVerityProject.IoC;
using SimpleVerityProject.Services.Interfaces;
using SimpleVerityProject.Web.Adapter;
using SimpleVerityProject.Web.Mappers;
using SimpleVerityProject.Web.Models;
using SimpleVerityProject.Web.Models.ModelsHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Controllers
{
    public class MovimentoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICosifService _cosifService;
        private readonly IMovimentoService _movimentoService;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MovimentoController()
        {
            var container = new IoCContainer().GetContainer();

            _movimentoService = container.GetInstance<IMovimentoService>();
            _produtoService = container.GetInstance<IProdutoService>();
            _cosifService = container.GetInstance<ICosifService>();
        }

        [HandleError]
        public ActionResult Index()
        {
            try
            {
                AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
                var mapper = autoMapperConfig.Configure().CreateMapper();

                var produtos = _produtoService.ListarProdutos();

                DropListMovimentoViewModel model = new DropListMovimentoViewModel();

                var produtosViewModels = mapper.Map<ProdutoViewModel[]>(produtos);

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
            catch (ApplicationException e)
            {
                logger.Error(e, e.Message);
                return View("Error", new HandleErrorInfo(e, "Error", "Index"));
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
                return View("Error", new HandleErrorInfo(e, "Error", "Index"));
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [HandleError]
        public ActionResult BuscarCosif(int produtoId)
        {
            try
            {
                AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
                var mapper = autoMapperConfig.Configure().CreateMapper();

                var cosifs = _cosifService.BuscarPorProdutoId(produtoId);

                var cosifViewModel = mapper.Map<CosifViewModel[]>(cosifs);

                return Json(cosifViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (ApplicationException e)
            {
                logger.Error(e, e.Message);
                return View("Error", new HandleErrorInfo(e, "Movimento", "Index"));
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
                return View("Error", new HandleErrorInfo(e, "Movimento", "Index"));
            }
        }

        [HttpPost]
        [HandleError]
        public ActionResult SalvarMovimento([Bind(Include = "MesDeReferencia,AnoDeReferencia,Lancamento,Valor,Descricao,DataCriacao,Usuario,Cosifs,CosifId,ProdutoId,ProdutosDisponiveis,CosifsDisponiveis")] MovimentoViewModel movimentoView)
        {
            try
            {
                movimentoView.Lancamento = _movimentoService.BuscarLancamentoPorMesAno(movimentoView.MesDeReferencia, movimentoView.AnoDeReferencia);

                var movimento = MovimentoAdapter.ViewModelToModel(movimentoView);

                var salvo = _movimentoService.Salvar(movimento);

                return Json(new { Resultado = salvo }, JsonRequestBehavior.AllowGet);
            }
            catch (ApplicationException e)
            {
                logger.Error(e, e.Message);
                return Json(new { Resultado = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
                return Json(new { Resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        [HandleError]
        public JsonResult ListarMovimento()
        {
            try
            {
                AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
                var mapper = autoMapperConfig.Configure().CreateMapper();

                var movimentos = _movimentoService.BuscarTodos();

                var movimentosViewModel = mapper.Map<MovimentoViewModel[]>(movimentos);

                return Json(movimentosViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                logger.Debug(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult IndexVue()
        {
            if (ModelState.IsValid)
            {
                AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
                var mapper = autoMapperConfig.Configure().CreateMapper();

                var produtos = _produtoService.ListarProdutos();

                var produtosModels = mapper.Map<List<ProdutoModel>>(produtos);
                                
                return Json(produtosModels);
            }

            return Json(JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult BuscarCosifVue(int produtoId)
        {
            if (ModelState.IsValid)
            { 
                AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
                var mapper = autoMapperConfig.Configure().CreateMapper();

                var cosifs = _cosifService.BuscarPorProdutoId(produtoId);

                var cosifViewModel = mapper.Map<List<CosifModel>>(cosifs);

                return Json(cosifViewModel, JsonRequestBehavior.AllowGet);
            }

            return Json(Response.Status, JsonRequestBehavior.DenyGet);
        }

        [HttpGet]
        public JsonResult ListarMovimentoVue()
        {
            if (ModelState.IsValid)
            {
                AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
                var mapper = autoMapperConfig.Configure().CreateMapper();

                var movimentos = _movimentoService.BuscarTodos();

                var movimentosModel = mapper.Map<MovimentoModel[]>(movimentos);

                return Json(movimentosModel, JsonRequestBehavior.AllowGet);
            }

            return Json(Response.Status, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult SalvarMovimentoVue([Bind(Include = "MesDeReferencia,AnoDeReferencia,Lancamento,Valor,Descricao,DataCriacao,Usuario,Cosifs,CosifId,ProdutoId,ProdutosDisponiveis,CosifsDisponiveis")] MovimentoModel movimentoModel)
        {
            if(ModelState.IsValid)
            { 
                movimentoModel.Lancamento = _movimentoService.BuscarLancamentoPorMesAno(movimentoModel.MesDeReferencia, movimentoModel.AnoDeReferencia);

                var movimento = MovimentoAdapter.ViewModelToModel(movimentoModel);

                var salvo = _movimentoService.Salvar(movimento);

                return Json(new { Resultado = salvo }, JsonRequestBehavior.AllowGet);
            }

            return Json(Response.Status, JsonRequestBehavior.DenyGet);
        }
    }
}