using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Data.Repositories.Base;
using SimpleVerityProject.Services.Interfaces;

namespace ProjectVerity.Services
{
    public class ProdutoService : IProdutoService
    {
        ProdutoRepository produtoRepository = new ProdutoRepository();

        public bool Salvar(Produto entidade)
        {
            return produtoRepository.Salvar(entidade);
        }

        public bool Excluir(int idEntidade)
        {
            return produtoRepository.Excluir(idEntidade);
        }

        public Produto BuscarPorId(int id)
        {
            return produtoRepository.BuscarPorId(id);
        }

        public IList<Produto> ListarTodos()
        {
            return produtoRepository.ListarTodos();
        }

        public IList<Produto> Listar(Func<Produto, bool> where)
        {
            throw new NotImplementedException();
        }

        public IList<Produto> ListarFiltrando(Expression<Func<Produto, bool>> predicate)
        {
            throw new NotImplementedException();
        }        
    }
}
