using System;
using System.Collections.Generic;

namespace SimpleVerityProject.Domain.Entities
{
    public class Movimento : BaseEntity
    {
        public int MesDeReferencia { get; set; }
        public int AnoDeReferencia { get; set; }
        public int Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string Usuario { get; set; }
        public int ProdutoId { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        public int CosifId { get; set; }
        public IEnumerable<Cosif> Cosifs { get; set; }
        
        public Movimento(int mesDeReferencia, int anoDeReferencia, int lancamento, decimal valor, string descricao, string usuario, int produtoId, int cosifId, DateTime? dateTime)
        {
            MesDeReferencia = mesDeReferencia;
            AnoDeReferencia = anoDeReferencia;
            Lancamento = lancamento;
            Valor = valor;
            Descricao = descricao;
            Usuario = usuario;
            ProdutoId = produtoId;
            CosifId = cosifId;
            DataCriacao = (dateTime != null) ? dateTime : DateTime.Now;
        }
    }
}
