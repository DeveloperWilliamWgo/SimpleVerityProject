using ProjectVerity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleVerityProject.Services.Interfaces
{
    public interface IProdutoService
    {
        bool Salvar(Produto entidade);
        bool Excluir(int idEntidade);

        Produto BuscarPorId(int id);
        IList<Produto> ListarTodos();
        IList<Produto> Listar(Func<Produto, bool> where);
        IList<Produto> ListarFiltrando(Expression<Func<Produto, bool>> predicate);
    }
}
