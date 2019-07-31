using System.Collections.Generic;
using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Domain;
using SimpleVerityProject.Services.Interfaces;

namespace SimpleVerityProject.Services.Services
{
    public class CosifService : ICosifService
    {
        CosifRepository cosifRepository = new CosifRepository();

        public Cosif BuscarPorId(int id)
        {
            return cosifRepository.BuscarPorId(id);
        }

        public List<Cosif> BuscarPorProdutoId(int produtoId)
        {
            return cosifRepository.BuscarPorProdutoId(produtoId);
        }

        public bool Excluir(int idEntidade)
        {
            return cosifRepository.Excluir(idEntidade);
        }

        public List<Cosif> ListarTodos()
        {
            return cosifRepository.ListarTodos();
        }

        public bool Salvar(Cosif entidade)
        {
            return cosifRepository.Salvar(entidade);
        }
    }
}
