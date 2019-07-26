using SimpleVerityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleVerityProject.Data
{
    public interface IRepositorio<T> where T : BaseEntity
    {
        bool Salvar(T entidade);
        bool Excluir(int idEntidade);

        T BuscarPorId(int id);
        IList<T> ListarTodos();
        IList<T> Listar(Func<T, bool> where);
        IList<T> ListarFiltrando(Expression<Func<T, bool>> predicate);
    }
}
