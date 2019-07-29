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

        public List<Produto> ListarTodos()
        {
            return produtoRepository.ListarTodos();
        }    
    }
}
