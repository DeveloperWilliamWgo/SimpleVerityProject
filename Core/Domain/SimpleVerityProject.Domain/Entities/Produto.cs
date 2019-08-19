namespace SimpleVerityProject.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        public Produto() { }

        public Produto(int produtoId, string descricao, bool ativo)
        {
            Id = produtoId;
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
