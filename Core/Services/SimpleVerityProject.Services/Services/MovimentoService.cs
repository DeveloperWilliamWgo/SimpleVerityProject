using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Data;
using SimpleVerityProject.Data.Repositories;
using SimpleVerityProject.Services.Interfaces;

namespace SimpleVerityProject.Services.Services
{
    public class MovimentoService : IMovimentoService
    {
        private readonly IMovimentoRepository _movimentoRepository;
        
        public MovimentoService(IMovimentoRepository movimentoRepository)
        {
            _movimentoRepository = movimentoRepository;
        }

        public int BuscarLancamentoPorMesAno(int mes, int ano)
        {
            return _movimentoRepository.BuscarLancamentoPorMesAno(mes, ano);
        }

        public bool Salvar(Movimento entidade)
        {
            return _movimentoRepository.Salvar(entidade);
        }
    }
}
