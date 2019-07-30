using System;
using System.Collections.Generic;

namespace SimpleVerityProject.Web.Models
{
    public class MovimentoViewModel
    {
        public int MesDeReferencia { get; set; }
        public int AnoDeReferencia { get; set; }
        public int Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Usuario { get; set; }
        public IEnumerable<CosifViewModel> Cosifs { get; set; }
    }
}