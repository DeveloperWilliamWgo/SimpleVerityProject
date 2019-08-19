using SimpleVerityProject.Domain.Entities;
using System.Collections.Generic;

namespace SimpleVerityProject.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ListarProdutos();
    }
}
