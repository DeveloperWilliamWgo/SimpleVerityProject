using SimpleVerityProject.Domain.Entities;

namespace ProjectVerity.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        public Produto() { }

        public Produto(int produtoId, string descricao, bool ativo)
        {
            ProdutoId = produtoId;
            Descricao = descricao;
            Ativo = ativo;
        }

        public Produto(string descricao, bool ativo)
        {
            Descricao = descricao;
            Ativo = ativo;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }
}
