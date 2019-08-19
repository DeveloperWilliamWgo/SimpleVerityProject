using SimpleVerityProject.Domain.Entities;
using System.Collections.Generic;

namespace SimpleVerityProject.Domain.Interfaces
{
    public interface ICosifRepository : IRepository<Cosif>
    {
        IEnumerable<Cosif> BuscarPorProdutoId(int produtoId);
    }
}
