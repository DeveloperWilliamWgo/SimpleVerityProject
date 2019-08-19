using SimpleVerityProject.Domain.Entities;
using System.Collections.Generic;

namespace SimpleVerityProject.Services.Interfaces
{
    public interface IProdutoService
    {
        bool Salvar(Produto entidade);

        IEnumerable<Produto> ListarProdutos();
    }
}
