using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using NLog;
using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Domain.Interfaces;

namespace SimpleVerityProject.Data.Repositories
{
    public class MovimentoRepository : ContextBase, IMovimentoRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool Salvar(Movimento entidade)
        {
            bool result = false;
            try
            {
                string sql = "";

                if (entidade.Id == 0)
                {
                    sql = @"INSERT INTO MOVIMENTO_MANUAL(DAT_MES, DAT_ANO, NUM_LANCAMENTO, VAL_VALOR, DES_DESCRICAO, DAT_MOVIMENTO, COD_USUARIO, COD_PRODUTO, COD_COSIF)
                                VALUES(@DAT_MES, @DAT_ANO, @NUM_LANCAMENTO, @VAL_VALOR, @DES_DESCRICAO, @DAT_MOVIMENTO, @COD_USUARIO, @COD_PRODUTO, @COD_COSIF);";
                    comando = CriarComando(sql);
                }

                CriarParametro(comando, "@DAT_MES", entidade.MesDeReferencia);
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

                comando.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                logger.Trace(ex.Message);
                throw;
            }
            finally
            {
                Dispose();
            }
            return result;
        }

        public int BuscarLancamentoPorMesAno(int mes, int ano)
        {
            int proximoLancamento = 1;

            try
            {
                CriarComando(" SELECT TOP 1 NUM_LANCAMENTO FROM  MOVIMENTO_MANUAL WHERE DAT_MES = @DAT_MES AND DAT_ANO = @DAT_ANO ORDER BY 1 DESC");

                comando.Parameters.Clear();

                CriarParametro(comando, "@DAT_MES", mes);
                comando.Parameters.Add(oParam);

                CriarParametro(comando, "@DAT_ANO", ano);
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
                logger.Trace(ex.Message);
                throw;
            }
            finally
            {
                Dispose();
            }

            return proximoLancamento;
        }

        public IEnumerable<Movimento> BuscarTodos()
        {
            IEnumerable<Movimento> movimentos;
            try
            {
                CriarComando("SELECT DAT_MES, DAT_ANO, NUM_LANCAMENTO, VAL_VALOR, DES_DESCRICAO, DAT_MOVIMENTO, COD_USUARIO, COD_PRODUTO, COD_COSIF FROM  MOVIMENTO_MANUAL ORDER BY DAT_MOVIMENTO DESC");

                comando.Parameters.Clear();

                AbrirConexaoComBancoDados();
                CriarLeitorExecutarComando(comando);

                movimentos = GetMovimentos(oReader.HasRows).ToList();
            }
            catch (Exception ex)
            {
                logger.Trace(ex.Message);
                throw;
            }
            finally
            {
                Dispose();
            }

            return movimentos;
        }

        public IEnumerable<Movimento> GetMovimentos(bool v)
        {
            while (oReader.Read() && oReader.HasRows)
            {
                yield return new Movimento(
                        (int)oReader["DAT_MES"],
                        (int)oReader["DAT_ANO"],
                        (int)oReader["NUM_LANCAMENTO"],
                        Convert.ToDecimal(oReader["VAL_VALOR"]),
                        oReader["DES_DESCRICAO"].ToString(),
                        oReader["COD_USUARIO"].ToString(),
                        (int)oReader["COD_PRODUTO"],
                        (int)oReader["COD_COSIF"],
                        Convert.ToDateTime(oReader["DAT_MOVIMENTO"]));
            }
        }
    }
}
