using ProjectVerity.Services;
using SimpleVerityProject.Services.Services;
using SimpleVerityProject.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Controllers
{
    public class MovimentoController : Controller
    {
        private ProdutoService produtoService = new ProdutoService();
        private CosifService cosifService = new CosifService();
        private MovimentoService movimentoService = new MovimentoService();

        // GET: Movimento
        public ActionResult Index()
        {
            var produtos = produtoService.ListarTodos();

            var model = new List<ProdutoViewModel>();


            foreach (var produto in produtos)
            {
                model.Add(new ProdutoViewModel
                {
                    Ativo = produto.Ativo,
                    Descricao = produto.Descricao
                });
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}