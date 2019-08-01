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

        [Range(1, 31, ErrorMessage = "Insira o dia do mês no máximo 31")]
        [StringLength(2, ErrorMessage = "Max 2 digitos")]
        [Required]
        public int MesDeReferencia { get; set; }

        [Range(1, 3000, ErrorMessage = "Insira o ano no máximo 3000")]
        [StringLength(2, ErrorMessage = "Max 4 digitos")]
        [Required]
        public int AnoDeReferencia { get; set; }

        public int Lancamento { get; set; }

        [DataType("Money")]
        [Required]
        public decimal Valor { get; set; }

        [Range(0, 18, ErrorMessage = "Permitido o máximo de 18 caracteres")]
        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Usuario { get; set; } = "TESTE";
        public IEnumerable<CosifViewModel> Cosifs { get; set; }

        [Required]
        public int CosifId { get; set; }

        [Required]
        public int ProdutoId { get; set; }



        public IList<SelectListItem> ProdutosDisponiveis { get; set; }
        public IList<SelectListItem> CosifsDisponiveis { get; set; }

    }
}