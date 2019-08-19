using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Web.Models;

namespace SimpleVerityProject.Web.Adapter
{
    public static class MovimentoAdapter
    {
        public static Movimento ViewModelToModel(MovimentoModel movimentoView)
        {
            return new Movimento(
                movimentoView.MesDeReferencia, 
                movimentoView.AnoDeReferencia,
                movimentoView.Lancamento,
                decimal.Parse(movimentoView.Valor.Replace(".", ",")),
                movimentoView.Descricao,
                "TESTE",
                movimentoView.ProdutoId,
                movimentoView.CosifId,
                null);
        }

        public static Movimento ViewModelToModel(MovimentoViewModel movimentoView)
        {
            return new Movimento(
                movimentoView.MesDeReferencia,
                movimentoView.AnoDeReferencia,
                movimentoView.Lancamento,
                decimal.Parse(movimentoView.Valor.Replace(".", ",")),
                movimentoView.Descricao,
                "TESTE",
                movimentoView.ProdutoId,
                movimentoView.CosifId,
                null);
        }
    }
}