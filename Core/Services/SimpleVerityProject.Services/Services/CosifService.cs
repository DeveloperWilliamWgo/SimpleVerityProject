using System.Collections.Generic;
using SimpleVerityProject.Data.Repositories;
using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Services.Interfaces;

namespace SimpleVerityProject.Services.Services
{
    public class CosifService : ICosifService
    {
        readonly CosifRepository cosifRepository = new CosifRepository();

        public IEnumerable<Cosif> BuscarPorProdutoId(int codProduto)
        {
            return cosifRepository.BuscarPorProdutoId(codProduto);
        }
       
        public bool Salvar(Cosif entidade)
        {
            return cosifRepository.Salvar(entidade);
        }
    }
}
