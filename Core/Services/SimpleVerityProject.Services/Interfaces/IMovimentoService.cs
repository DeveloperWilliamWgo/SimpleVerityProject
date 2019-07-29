using ProjectVerity.Domain.Entities;

namespace SimpleVerityProject.Services.Interfaces
{
    public interface IMovimentoService
    {
        bool Salvar(Movimento entidade);
        int BuscarLancamentoPorMesAno(int mes, int ano);
    }
}
