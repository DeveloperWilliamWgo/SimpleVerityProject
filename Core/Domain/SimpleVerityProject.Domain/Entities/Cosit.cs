using SimpleVerityProject.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ProjectVerity.Domain.Entities
{
    public class Cosif : BaseEntity
    {
        public string Classificacao { get; set; }
        public bool Ativo { get; set; }
        public int ProdutoId { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataCriacao { get; set; }

        public Cosif() { }

        public Cosif(int cosifId, string classificacao, bool ativo, List<Produto> produtos)
        {
            Id = cosifId;
            Classificacao = classificacao;
            Ativo = ativo;
            Produtos = produtos;
        }

        public Cosif(string classificacao, bool ativo, List<Produto> produtos)
        {
            Classificacao = classificacao;
            Ativo = ativo;
            Produtos = produtos;
        }
    }
}
