using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleVerityProject.Web.Models
{
    public class ProdutoViewModel
    {

        public ProdutoViewModel()
        {
            ProdutosDisponivel = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public IList<SelectListItem> ProdutosDisponivel { get; set; }
    }
}