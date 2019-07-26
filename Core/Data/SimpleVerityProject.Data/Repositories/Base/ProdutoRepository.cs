using ProjectVerity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;

namespace SimpleVerityProject.Data.Repositories.Base
{
    public class ProdutoRepository : RepositorioBase<Produto, ProdutoRepository>, IRepositorio<Produto>
    {
        public bool Salvar(Produto entidade)
        {
            bool result = false;
            try
            {
                string sql = "";

                if (entidade.ProdutoId == 0)
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

                if (entidade.ProdutoId > 0)
                {
                    DbParameter novoParametro = CriarParametro(comando, "@COD_PRODUTO", entidade.ProdutoId);
                    comando.Parameters.Add(novoParametro);
                }
                AbrirConexaoComBancoDados();
                int linhas = comando.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                throw;
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
                throw;
            }
            finally
            {
                DesconectarComBancoDados();
            }
            return entidade;
        }

        public IList<Produto> ListarTodos()
        {
            List<Produto> entidades = new List<Produto>();

            try
            {
                CriarComando(" SELECT  COD_PRODUTO, DES_PRODUTO, STA_STATUS FROM  PRODUTO ORDER BY 1 DESC;");

                comando.Parameters.Clear();

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                Produto entidade = null;
                if (oReader.Read() && oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        entidades.Add(new Produto((int)oReader["COD_PRODUTO"], oReader["DES_PRODUTO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"])));

                        entidades.Add(entidade);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                DesconectarComBancoDados();
            }
            return entidades;
        }

        public IList<Produto> Listar(Func<Produto, bool> where)
        {
            throw new NotImplementedException();
        }

        public IList<Produto> ListarFiltrando(Expression<Func<Produto, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
