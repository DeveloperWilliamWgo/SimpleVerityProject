using ProjectVerity.Domain.Entities;
using System.Collections.Generic;

namespace SimpleVerityProject.Services.Interfaces
{
    public interface ICosifService
    {
        bool Salvar(Cosif entidade);
        bool Excluir(int idEntidade);
        Cosif BuscarPorId(int id);
        List<Cosif> ListarTodos();
    }
}
