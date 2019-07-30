using System;
using System.Collections.Generic;

namespace SimpleVerityProject.Web.Models
{
    public class CosifViewModel
    {
        public string Classificacao { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}