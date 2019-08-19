using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string Valor { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataCriacao { get; set; }

        public string Usuario { get; set; } = "TESTE";

        public int ProdutoId { get; set; }

        public int CosifId { get; set; }

        public IEnumerable<CosifViewModel> Cosifs { get; set; }
               

        
        public IList<SelectListItem> ProdutosDisponiveis { get; set; }
        public IList<SelectListItem> CosifsDisponiveis { get; set; }

    }
}