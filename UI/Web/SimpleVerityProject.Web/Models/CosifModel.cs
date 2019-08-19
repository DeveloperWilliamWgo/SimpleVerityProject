using System;
using System.Collections.Generic;

namespace SimpleVerityProject.Web.Models
{
    public class CosifModel
    {
        public int Id { get; set; }
        public string Classificacao { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<ProdutoModel> Produtos { get; set; }
    }
}
