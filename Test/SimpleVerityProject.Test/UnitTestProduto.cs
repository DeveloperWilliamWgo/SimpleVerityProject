using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectVerity.Domain.Entities;
using ProjectVerity.Services;

namespace SimpleVerityProject.Test
{
    [TestClass]
    public class UnitTestProduto
    {
        [TestMethod]
        public void DeveSerPossivelCadastrarProduto()
        {
            ProdutoService produtoService = new ProdutoService();

            var produto = new Produto("Caneta", true);

            var response = produtoService.Salvar(produto);

            Assert.IsTrue(response);
        }
    }
}
