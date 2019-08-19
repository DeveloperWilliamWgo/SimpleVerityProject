using System.Collections.Generic;
using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Domain.Interfaces;
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

        public bool Salvar(Movimento entidade)
        {
            return _movimentoRepository.Salvar(entidade);
        }

        public int BuscarLancamentoPorMesAno(int mes, int ano)
        {
            return _movimentoRepository.BuscarLancamentoPorMesAno(mes, ano);
        }

        public IEnumerable<Movimento> BuscarTodos()
        {
            return _movimentoRepository.BuscarTodos();
        }
    }
}
