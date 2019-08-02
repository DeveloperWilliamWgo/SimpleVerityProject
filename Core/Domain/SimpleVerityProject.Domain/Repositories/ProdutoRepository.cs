using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SimpleVerityProject.Domain
{
    public class ProdutoRepository : RepositorioBase<Produto, ProdutoRepository>, IProdutoRepository
    {
        public bool Salvar(Produto entidade)
        {
            bool result = false;
            try
            {
                string sql = "";

                if (entidade.Id == 0)
                {
                    sql = @"INSERT INTO PRODUTO(DES_PRODUTO, STA_STATUS) values(@DES_PRODUTO, @STA_STATUS);";
                    comando = CriarComando(sql);
                }
                else
                {
                    sql = @"UPDATE PRODUTO SET DES_PRODUTO = @DES_PRODUTO WHERE COD_PRODUTO = @COD_PRODUTO";
                    comando = CriarComando(sql);
                }

                CriarParametro(comando, "@DES_PRODUTO", entidade.Descricao);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@STA_STATUS", entidade.Ativo);
                comando.Parameters.Add(oParam);

                if (entidade.Id > 0)
                {
                    DbParameter novoParametro = CriarParametro(comando, "@COD_PRODUTO", entidade.Id);
                    comando.Parameters.Add(novoParametro);
                }
                AbrirConexaoComBancoDados();
                int linhas = comando.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro - {ex.Message}", ex);
            }
            finally
            {
                DesconectarComBancoDados();
            }
            return result;
        }

        public bool Excluir(int idEntidade)
        {
            bool result = false;
            try
            {
                string sql = "";

                if (idEntidade > 0)
                {
                    sql = @"DELETE FROM PRODUTO WHERE COD_PRODUTO = @COD_PRODUTO";
                }
                else
                {
                    return result;
                }
                CriarComando(sql);

                CriarParametro(comando, "@COD_PRODUTO", idEntidade);
                comando.Parameters.Add(oParam);

                AbrirConexaoComBancoDados();

                int linhas = comando.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DesconectarComBancoDados();
            }
            return result;
        }

        public Produto BuscarPorId(int id)
        {
            Produto entidade = new Produto();
            try
            {
                CriarComando(" SELECT * FROM  PRODUTO WHERE COD_PRODUTO = @COD_PRODUTO");

                comando.Parameters.Clear();

                CriarParametro(comando, "@COD_PRODUTO", id);

                comando.Parameters.Add(oParam);

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                if (oReader.Read() && oReader.HasRows)
                {
                    entidade = new Produto(oReader["DES_PRODUTO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"]));
                }
                else
                {
                    entidade = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro - {ex.Message}", ex);
            }
            finally
            {
                DesconectarComBancoDados();
            }
            return entidade;
        }

        public List<Produto> ListarTodos()
        {
            List<Produto> entidades = new List<Produto>();

            try
            {
                CriarComando("SELECT * FROM PRODUTO ORDER BY 1 ASC;");

                comando.Parameters.Clear();
                
                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                while (oReader.Read())
                {
                    if (oReader.GetInt32(0) > 0)
                    {
                        entidades.Add(new Produto((int)oReader["COD_PRODUTO"], oReader["DES_PRODUTO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"])));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro - {ex.Message}", ex);
            }
            finally
            {
                DesconectarComBancoDados();
            }
            return entidades;
        }
    }
}
