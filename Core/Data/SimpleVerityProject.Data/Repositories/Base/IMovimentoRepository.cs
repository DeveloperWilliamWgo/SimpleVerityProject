using ProjectVerity.Domain.Entities;

namespace SimpleVerityProject.Data
{
    public interface IMovimentoRepository : IRepository<Movimento>
    {
        int BuscarLancamentoPorMesAno(int mes, int ano);
    }
}
