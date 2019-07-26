using System;
using System.Collections.Generic;

namespace ProjectVerity.Domain.Entities
{
    public class Cosif
    {
        public Guid CosifId { get; set; }
        public string Classificacao { get; set; }
        public bool Ativo { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataCriacao { get; set; }


        public Cosif(string classificacao, bool ativo, List<Produto> produtos)
        {
            Classificacao = classificacao;
            Ativo = ativo;
            Produtos = produtos;
        }
    }
}
