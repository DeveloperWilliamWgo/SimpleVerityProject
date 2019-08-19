using SimpleVerityProject.Domain.Entities;
using System.Collections.Generic;

namespace SimpleVerityProject.Services.Interfaces
{
    public interface ICosifService
    {
        bool Salvar(Cosif entidade);       
        IEnumerable<Cosif> BuscarPorProdutoId(int codProduto);
    }
}
