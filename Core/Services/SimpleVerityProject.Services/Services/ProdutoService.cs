using System.Collections.Generic;
using SimpleVerityProject.Data.Repositories;
using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Services.Interfaces;

namespace ProjectVerity.Services
{
    public class ProdutoService : IProdutoService
    {
        readonly ProdutoRepository produtoRepository = new ProdutoRepository();

        public bool Salvar(Produto entidade)
        {
            return produtoRepository.Salvar(entidade);
        }
        
        public IEnumerable<Produto> ListarProdutos()
        {
            return produtoRepository.ListarProdutos();
        }    
    }
}
