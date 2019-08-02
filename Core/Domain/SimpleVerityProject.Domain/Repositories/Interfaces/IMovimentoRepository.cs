using System.Collections.Generic;
using ProjectVerity.Domain.Entities;

namespace SimpleVerityProject.Domain
{
    public interface IMovimentoRepository : IRepository<Movimento>
    {
        int BuscarLancamentoPorMesAno(int mes, int ano);
        List<Movimento> BuscarTodos();
    }
}
