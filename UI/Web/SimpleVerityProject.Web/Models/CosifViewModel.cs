using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Models
{
    public class CosifViewModel
    {
        public CosifViewModel()
        {
            CosifsDisponivel = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public string Classificacao { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public DateTime DataCriacao { get; set; }

        public IList<SelectListItem> CosifsDisponivel { get; set; }
    }
}
