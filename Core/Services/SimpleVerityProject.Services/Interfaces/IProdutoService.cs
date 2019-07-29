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
        List<Produto> ListarTodos();
    }
}
