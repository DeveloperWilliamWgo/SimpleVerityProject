using System;

namespace ProjectVerity.Domain.Entities
{
    public class Movimento
    {
        public Guid MovimentoId { get; set; }
        public int MesDeReferencia { get; set; }
        public int AnoDeReferencia { get; set; }
        public int Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Usuario { get; set; }
        public Produto Produto { get; set; }
        public Cosif Cosit { get; set; }
    }
}
