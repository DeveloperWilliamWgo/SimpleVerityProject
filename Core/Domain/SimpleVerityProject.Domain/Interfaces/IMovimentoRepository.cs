using System.Collections.Generic;
using SimpleVerityProject.Domain.Entities;

namespace SimpleVerityProject.Domain.Interfaces
{
    public interface IMovimentoRepository : IRepository<Movimento>
    {
        int BuscarLancamentoPorMesAno(int mes, int ano);
        IEnumerable<Movimento> BuscarTodos();
    }
}
