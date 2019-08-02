using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Web.Models;

namespace SimpleVerityProject.Web.Adapter
{
    public static class MovimentoAdapter
    {
        public static Movimento ViewModelToModel(MovimentoViewModel movimentoView)
        {
            return new Movimento(
                movimentoView.MesDeReferencia, 
                movimentoView.AnoDeReferencia,
                movimentoView.Lancamento,
                decimal.Parse(movimentoView.Valor.Replace(".", ",")),
                movimentoView.Descricao,
                movimentoView.Usuario,
                movimentoView.ProdutoId,
                movimentoView.CosifId);
        }
    }
}