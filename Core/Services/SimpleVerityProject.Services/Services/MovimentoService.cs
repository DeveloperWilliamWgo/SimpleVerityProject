using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Data.Repositories;
using SimpleVerityProject.Services.Interfaces;

namespace SimpleVerityProject.Services.Services
{
    public class MovimentoService : IMovimentoService
    {
        MovimentoRepository movimentoRepository = new MovimentoRepository();

        public int BuscarLancamentoPorMesAno(int mes, int ano)
        {
            return movimentoRepository.BuscarLancamentoPorMesAno(mes, ano);
        }

        public bool Salvar(Movimento entidade)
        {
            return movimentoRepository.Salvar(entidade);
        }
    }
}
