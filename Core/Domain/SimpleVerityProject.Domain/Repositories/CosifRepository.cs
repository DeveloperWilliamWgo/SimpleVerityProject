using System;
using System.Collections.Generic;
using System.Data.Common;
using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Data;

namespace SimpleVerityProject.Domain
{
    public class CosifRepository : RepositorioBase<Cosif, CosifRepository>, ICosifRepository
    {
        public bool Salvar(Cosif entidade)
        {
            bool result = false;
            try
            {
                string sql = "";

                if (entidade.Id == 0)
                {
                    sql = @"INSERT INTO COSIF(COD_CLASSIFICACAO, STA_STATUS, COD_PRODUTO) values(@COD_CLASSIFICACAO, @STA_STATUS, @COD_PRODUTO);";
                    comando = CriarComando(sql);
                }

                CriarParametro(comando, "@COD_CLASSIFICACAO", entidade.Classificacao);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@STA_STATUS", entidade.Ativo);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@COD_PRODUTO", entidade.ProdutoId);
                comando.Parameters.Add(oParam);

                if (entidade.Id > 0)
                {
                    DbParameter novoParametro = CriarParametro(comando, "@COD_COSIF", entidade.Id);
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

        public List<Cosif> BuscarPorProdutoId(int codProduto)
        {
            var cosif = new List<Cosif>();
            List<Produto> produtos = new List<Produto>();
            try
            {
                CriarComando("SELECT * FROM COSIF CO INNER JOIN PRODUTO PRO ON PRO.COD_PRODUTO = CO.COD_PRODUTO WHERE COD_PRODUTO = @COD_PRODUTO;");

                comando.Parameters.Clear();

                CriarParametro(comando, "@COD_PRODUTO", codProduto);

                comando.Parameters.Add(oParam);

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                while (oReader.Read() && oReader.HasRows)
                {
                    produtos.Add(new Produto((int)oReader["COD_PRODUTO"], oReader["DES_PRODUTO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"])));

                    cosif.Add(new Cosif((int)oReader["COD_COSIF"], oReader["COD_CLASSIFICACAO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"]), produtos));
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

            return cosif;
        }

        public bool Excluir(int idEntidade)
        {
            bool result = false;
            try
            {
                string sql = "";

                if (idEntidade > 0)
                {
                    sql = @"DELETE FROM COSIF WHERE COD_COSIF = @COD_COSIF";
                }
                else
                {
                    return result;
                }
                CriarComando(sql);

                CriarParametro(comando, "@COD_COSIF", idEntidade);
                comando.Parameters.Add(oParam);

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

        public Cosif BuscarPorId(int id)
        {
            Cosif cosif = new Cosif();
            List<Produto> produtos = new List<Produto>();
            try
            {
                CriarComando("SELECT * FROM COSIF CO INNER JOIN PRODUTO PRO ON PRO.COD_PRODUTO = CO.COD_PRODUTO WHERE COD_COSIF = @COD_COSIF;");

                comando.Parameters.Clear();

                CriarParametro(comando, "@COD_COSIF", id);

                comando.Parameters.Add(oParam);

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                while (oReader.Read() && oReader.HasRows)
                {
                    produtos.Add(new Produto((int)oReader["COD_PRODUTO"], oReader["DES_PRODUTO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"])));

                    cosif = new Cosif((int)oReader["COD_COSIF"], oReader["COD_CLASSIFICACAO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"]), produtos);
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

            return cosif;
        }

        public List<Cosif> ListarTodos()
        {
            List<Produto> produtos = new List<Produto>();

            List<Cosif> cosifs = new List<Cosif>();
            
            try
            {
                CriarComando("SELECT * FROM COSIF CO INNER JOIN PRODUTO PRO ON PRO.COD_PRODUTO = CO.COD_PRODUTO ORDER BY 1 DESC");

                comando.Parameters.Clear();

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                if (oReader.Read() && oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        produtos.Add(new Produto((int)oReader["COD_PRODUTO"], oReader["DES_PRODUTO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"])));

                        cosifs.Add(new Cosif((int)oReader["COD_COSIF"], oReader["COD_CLASSIFICACAO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"]), produtos));
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

            return cosifs;
        }
    }
}
