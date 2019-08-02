using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Models.ModelsHelper
{
    public class DropListMovimentoViewModel
    {
        public DropListMovimentoViewModel()
        {
            ProdutosDisponiveis = new List<SelectListItem>();
            CosifsDisponiveis = new List<SelectListItem>();
        }

        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Cosif")]
        public int CosifId { get; set; }

        public IList<SelectListItem> ProdutosDisponiveis { get; set; }
        public IList<SelectListItem> CosifsDisponiveis { get; set; }
    }
}