using ProjectVerity.Domain.Entities;
using System.Collections.Generic;

namespace SimpleVerityProject.Services.Interfaces
{
    public interface IMovimentoService
    {
        bool Salvar(Movimento entidade);
        int BuscarLancamentoPorMesAno(int mes, int ano);
        List<Movimento> BuscarTodos();
    }
}
