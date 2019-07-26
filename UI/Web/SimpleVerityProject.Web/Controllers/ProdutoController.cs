using SimpleVerityProject.Services.Interfaces;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var produtos = _produtoService.ListarTodos();

            return View(produtos);
        }
    }
}