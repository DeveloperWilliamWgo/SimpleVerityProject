using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using ProjectVerity.Domain.Entities;
using SimpleVerityProject.Data;

namespace SimpleVerityProject.Domain
{
    public class MovimentoRepository : RepositorioBase<Movimento, MovimentoRepository>, IMovimentoRepository
    {
        public bool Salvar(Movimento entidade)
        {
            bool result = false;
            try
            {
                string sql = "";

                if (entidade.Id == 0)
                {
                    sql = @"INSERT INTO MOVIMENTO_MANUAL(DAT_MÊS, DAT_ANO, NUM_LANCAMENTO, VAL_VALOR, DES_DESCRICAO, DAT_MOVIMENTO, COD_USUARIO, COD_PRODUTO, COD_COSIF)
                                VALUES(@DAT_MÊS, @DAT_ANO, @NUM_LANCAMENTO, @VAL_VALOR, @DES_DESCRICAO, @DAT_MOVIMENTO, @COD_USUARIO, @COD_PRODUTO, @COD_COSIF);";
                    comando = CriarComando(sql);
                }

                CriarParametro(comando, "@DAT_MÊS", entidade.MesDeReferencia);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@DAT_ANO", entidade.AnoDeReferencia);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@NUM_LANCAMENTO", entidade.Lancamento);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@VAL_VALOR", entidade.Valor);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@DES_DESCRICAO", entidade.Descricao);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@DAT_MOVIMENTO", entidade.DataCriacao);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@COD_USUARIO", entidade.Usuario);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@COD_PRODUTO", entidade.ProdutoId);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@COD_COSIF", entidade.CosifId);
                comando.Parameters.Add(oParam);

                if (entidade.Id > 0)
                {
                    DbParameter novoParametro = CriarParametro(comando, "@COD_MOV", entidade.Id);
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
            try
            {
                string sql = "";

                if (idEntidade > 0)
                {
                    sql = @"DELETE FROM MOVIMENTO_MANUAL WHERE COD_MOV = @COD_MOV";
                }
                else
                {
                    return false;
                }
                CriarComando(sql);

                CriarParametro(comando, "@COD_MOV", idEntidade);
                comando.Parameters.Add(oParam);

                AbrirConexaoComBancoDados();

                int linhas = comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro - {ex.Message}", ex);
            }
            finally
            {
                DesconectarComBancoDados();
            }
        }

        public Movimento BuscarPorId(int id)
        {
            Movimento entidade = new Movimento();

            try
            {
                CriarComando(" SELECT TOP 1 * FROM  MOVIMENTO_MANUAL WHERE COD_MOV = @COD_MOV ORDER BY 1 DESC");

                comando.Parameters.Clear();

                CriarParametro(comando, "@COD_MOV", id);

                comando.Parameters.Add(oParam);

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                List<Produto> prod = new List<Produto>();
                List<Cosif> cosifs = new List<Cosif>();


                if (oReader.Read() && oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        prod.Add(new Produto((int)oReader["COD_PRODUTO"], oReader["DES_PRODUTO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"])));


                        cosifs.Add(new Cosif((int)oReader["COD_COSIF"], oReader["COD_CLASSIFICACAO"].ToString(), Convert.ToBoolean(oReader["STA_STATUS"]), prod));

                        entidade = new Movimento
                        {
                            MesDeReferencia = (int)oReader["DAT_MÊS"],
                            AnoDeReferencia = (int)oReader["DAT_ANO"],
                            Lancamento = (int)oReader["NUM_LANCAMENTO"],
                            Valor = Convert.ToDecimal(oReader["VAL_VALOR"]),
                            Descricao = oReader["DES_DESCRICAO"].ToString(),
                            DataCriacao = Convert.ToDateTime(oReader["DAT_MOVIMENTO"]),
                            Usuario = oReader["COD_USUARIO"].ToString(),
                            ProdutoId = prod.Select(_ => _.Id).FirstOrDefault(),
                            CosifId = cosifs.Select(_ => _.Id).FirstOrDefault()
                        };
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

            return entidade;
        }

        public int BuscarLancamentoPorMesAno(int mes, int ano)
        {
            int proximoLancamento = 1;

            try
            {
                CriarComando(" SELECT TOP 1 NUM_LANCAMENTO FROM  MOVIMENTO_MANUAL WHERE DAT_MES = @DAT_MES AND DAT_ANO = DAT_ANO ORDER BY 1 DESC");

                comando.Parameters.Clear();

                CriarParametro(comando, "@DAT_MES", mes);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@DAT_ANO", mes);
                comando.Parameters.Add(oParam);

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                if (oReader.Read() && oReader.HasRows)
                {
                    proximoLancamento = (int)oReader["NUM_LANCAMENTO"] + 1;
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

            return proximoLancamento;
        }
    }
}
