using System;
using System.Collections.Generic;

namespace SimpleVerityProject.Domain.Entities
{
    public class Cosif : BaseEntity
    {
        public string Classificacao { get; set; }
        public bool Ativo { get; set; }
        public int ProdutoId { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        
        public Cosif(int cosifId, string classificacao, bool ativo, IEnumerable<Produto> produtos)
        {
            Id = cosifId;
            Classificacao = classificacao;
            Ativo = ativo;
            Produtos = produtos;
        }
    }
}
