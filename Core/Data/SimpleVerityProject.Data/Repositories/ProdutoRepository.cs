using SimpleVerityProject.Domain.Entities;
using SimpleVerityProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SimpleVerityProject.Data.Repositories
{
    public class ProdutoRepository : ContextBase, IProdutoRepository
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

                comando.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro - {ex.Message}", ex);
            }
            finally
            {
                DesconectarComBancoDados();
            }
            return result;
        }
        
        public IEnumerable<Produto> ListarProdutos()
        {
            List<Produto> entidades = new List<Produto>();

            try
            {
                CriarComando("SELECT COD_PRODUTO, DES_PRODUTO, STA_STATUS FROM PRODUTO ORDER BY 1 ASC;");

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
                throw new ArgumentException($"Erro - {ex.Message}", ex);
            }
            finally
            {
                DesconectarComBancoDados();
            }
            return entidades;
        }
    }
}
