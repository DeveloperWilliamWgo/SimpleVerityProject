using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}