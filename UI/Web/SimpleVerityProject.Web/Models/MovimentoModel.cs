using System;
using System.Collections.Generic;

namespace SimpleVerityProject.Web.Models
{
    public class MovimentoModel
    {
        public int MesDeReferencia { get; set; }

        public int AnoDeReferencia { get; set; }

        public int Lancamento { get; set; }

        public string Valor { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataCriacao { get; set; }

        public string Usuario { get; set; } = "TESTE";

        public int ProdutoId { get; set; }

        public IEnumerable<ProdutoModel> Produtos { get; set; }

        public int CosifId { get; set; }

        public IEnumerable<CosifModel> Cosifs { get; set; }

    }
}