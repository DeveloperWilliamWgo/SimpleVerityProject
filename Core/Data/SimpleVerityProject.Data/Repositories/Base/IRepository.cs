using SimpleVerityProject.Domain.Entities;

namespace SimpleVerityProject.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Salvar(T entidade);
        bool Excluir(int idEntidade);

        T BuscarPorId(int id);
    }
}
