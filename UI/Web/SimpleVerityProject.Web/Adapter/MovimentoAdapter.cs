using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Web.Models;
using System;

namespace SimpleVerityProject.Web.Adapter
{
    public static class MovimentoAdapter
    {
        public static Movimento ViewModelToModel(MovimentoViewModel movimentoView)
        {
            return new Movimento {
                MesDeReferencia = movimentoView.MesDeReferencia,
                AnoDeReferencia = movimentoView.AnoDeReferencia,
                CosifId = movimentoView.CosifId,
                ProdutoId = movimentoView.ProdutoId,
                DataCriacao = DateTime.Now,
                Descricao = movimentoView.Descricao,
                Lancamento = movimentoView.Lancamento,
                Valor = movimentoView.Valor
            };
        }
    }
}