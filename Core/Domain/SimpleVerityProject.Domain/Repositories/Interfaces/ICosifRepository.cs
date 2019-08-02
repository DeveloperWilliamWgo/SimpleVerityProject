using ProjectVerity.Domain.Entities;
using System.Collections.Generic;

namespace SimpleVerityProject.Domain
{
    public interface ICosifRepository : IRepository<Cosif>
    {
        List<Cosif> BuscarPorProdutoId(int produtoId);
    }
}
