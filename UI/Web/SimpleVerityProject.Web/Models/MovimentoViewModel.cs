using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Models
{
    public class MovimentoViewModel
    {
        public MovimentoViewModel()
        {
            ProdutosDisponiveis = new List<SelectListItem>();
            CosifsDisponiveis = new List<SelectListItem>();
        }

        public int MesDeReferencia { get; set; }
        public int AnoDeReferencia { get; set; }
        public int Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Usuario { get; set; }
        public IEnumerable<CosifViewModel> Cosifs { get; set; }


        public IList<SelectListItem> ProdutosDisponiveis { get; set; }
        public IList<SelectListItem> CosifsDisponiveis { get; set; }

    }
}