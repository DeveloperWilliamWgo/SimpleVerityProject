using SimpleVerityProject.Domain.Entities;

namespace SimpleVerityProject.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Salvar(T entidade);
    }
}
