//using ProjectVerity.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;

//namespace SimpleVerityProject.Data.Dao
//{
//    public class ProdutoDao
//    {
//        private string connectionstring = ConfigurationManager.ConnectionStrings["banco"].ConnectionString;

//        public void BuscarTodos(Produto produto)
//        {
//            using (IDbConnection conexao = new SqlConnection(connectionstring))
//            using (IDbCommand comando = conexao.CreateCommand())
//            {
//                comando.CommandText = "INSERT INTO (COD_PRODUTO , DES_PRODUTO, STA_STATUS) values (@COD_PRODUTO , @DES_PRODUTO, @STA_STATUS);";

//                IDbDataParameter paramCod_Prod = comando.CreateParameter();
//                paramCod_Prod.ParameterName = "COD_PRODUTO";
//                paramCod_Prod.Value = produto.ProdutoId;

//                IDbDataParameter paramDescricao = comando.CreateParameter();
//                paramDescricao.ParameterName = "DES_PRODUTO";
//                paramDescricao.Value = produto.Descricao;

//                IDbDataParameter paramStatus = comando.CreateParameter();
//                paramStatus.ParameterName = "STA_STATUS";
//                paramStatus.Value = produto.ProdutoId;

//                comando.Parameters.Add(paramCod_Prod);
//                comando.Parameters.Add(paramDescricao);
//                comando.Parameters.Add(paramStatus);

//                conexao.Open();
//                comando.ExecuteNonQuery();
//            }
//        }

//        public Produto BuscaPorId(int id)
//        {
//            using (IDbConnection conexao = new SqlConnection(connectionstring))
//            using (IDbCommand comando = conexao.CreateCommand())
//            {
//                comando.CommandText = "SELECT * FROM PRODUTO WHERE COD_PRODUTO = @COD_PRODUTO;";

//                IDbDataParameter paramCod_Prod = comando.CreateParameter();
//                paramCod_Prod.ParameterName = "COD_PRODUTO";
//                paramCod_Prod.Value = id;

//                comando.Parameters.Add(paramCod_Prod);

//                conexao.Open();
//                IDataReader dr = comando.ExecuteReader();

//                Produto produto = null;

//                if (dr.Read())
//                {
//                    while (dr.Read())
//                    {

//                    }
//                    produto = new Produto(dr["id"].ToString(), dr["nome"].ToString(), Convert.ToBoolean(dr["descricao"]));
//                }

//                return produto;
//            }
//        }

//        public void Altera(Produto produto)
//        {
//            using (IDbConnection conexao = new SqlConnection(connectionstring))
//            using (IDbCommand comando = conexao.CreateCommand())
//            {
//                comando.CommandText = "update produto set nome = @nome, descricao = @descricao where id = @id";

//                IDbDataParameter paramId = comando.CreateParameter();
//                paramId.ParameterName = "id";
//                paramId.Value = produto.ProdutoId;

//                IDbDataParameter paramNome = comando.CreateParameter();
//                paramNome.ParameterName = "nome";
//                paramNome.Value = produto.Nome;

//                IDbDataParameter paramDescricao = comando.CreateParameter();
//                paramDescricao.ParameterName = "descricao";
//                paramDescricao.Value = produto.Descricao;

//                comando.Parameters.Add(paramId);
//                comando.Parameters.Add(paramNome);
//                comando.Parameters.Add(paramDescricao);

//                conexao.Open();
//                comando.ExecuteNonQuery();
//            }
//        }

//        public List<Produto> Lista()
//        {
//            using (IDbConnection conexao = new SqlConnection(connectionstring))
//            using (IDbCommand comando = conexao.CreateCommand())
//            {
//                comando.CommandText = "select * from produto";

//                conexao.Open();
//                IDataReader dr = comando.ExecuteReader();

//                List<Produto> lista = new List<Produto>();
//                while (dr.Read())
//                {
//                    Produto produto = new Produto();
//                    produto = new Produto();
//                    produto.Id = Convert.ToInt32(dr["id"]);
//                    produto.Nome = dr["nome"].ToString();
//                    produto.Descricao = dr["descricao"].ToString();

//                    lista.Add(produto);
//                }

//                return lista;
//            }
//        }

//        public void Exclui(int id)
//        {
//            using (IDbConnection conexao = new SqlConnection(connectionstring))
//            using (IDbCommand comando = conexao.CreateCommand())
//            {
//                comando.CommandText = "delete from produto where id = @id";

//                IDbDataParameter paramId = comando.CreateParameter();
//                paramId.ParameterName = "id";
//                paramId.Value = id;

//                comando.Parameters.Add(paramId);

//                conexao.Open();
//                comando.ExecuteNonQuery();
//            }
//        }
//    }
//}
