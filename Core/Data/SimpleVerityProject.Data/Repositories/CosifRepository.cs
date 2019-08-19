using System;
using System.Collections.Generic;
using System.Data.Common;
using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Domain.Interfaces;

namespace SimpleVerityProject.Data.Repositories
{
    public class CosifRepository : ContextBase, ICosifRepository
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

                comando.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException($"Erro - {ex.Message}", ex);
            }
            finally
            {
                Dispose();
            }
            return result;
        }

        public IEnumerable<Cosif> BuscarPorProdutoId(int produtoId)
        {
            var cosif = new List<Cosif>();

            try
            {
                CriarComando(string.Concat("SELECT CO.COD_COSIF, CO.COD_CLASSIFICACAO, CO.STA_STATUS, PRO.COD_PRODUTO AS PROD_ID, PRO.DES_PRODUTO, PRO.STA_STATUS AS PROD_STATUS ",
                                            "FROM COSIF CO INNER JOIN PRODUTO PRO ON PRO.COD_PRODUTO = CO.COD_PRODUTO WHERE CO.COD_PRODUTO = @COD_PRODUTO;"));

                comando.Parameters.Clear();

                CriarParametro(comando, "@COD_PRODUTO", produtoId);

                comando.Parameters.Add(oParam);

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                while (oReader.Read() && oReader.HasRows)
                {
                    cosif.Add(new Cosif((int)oReader["COD_COSIF"], oReader["COD_CLASSIFICACAO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"]), new List<Produto> { new Produto((int)oReader["PROD_ID"], oReader["DES_PRODUTO"].ToString(), Convert.ToBoolean(oReader["PROD_STATUS"])) }));
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException($"Erro - {ex.Message}", ex);
            }
            finally
            {
                DesconectarComBancoDados();
            }

            return cosif;
        }
    }
}
