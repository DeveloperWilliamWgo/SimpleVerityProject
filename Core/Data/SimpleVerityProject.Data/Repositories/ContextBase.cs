using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace SimpleVerityProject.Data.Repositories
{
    public abstract class ContextBase : IDisposable
    {
        protected DbCommand comando;
        protected DbConnection oConn;
        protected DbProviderFactory oProvider;
        protected DbDataReader oReader;
        protected DbParameter oParam;

        protected ContextBase() : this("")
        {
        }

        protected ContextBase(string nomeProvider)
        {
            if (string.IsNullOrWhiteSpace(nomeProvider))
            {
                nomeProvider = ConfigurationManager.ConnectionStrings["MinhaConnectionString"].ProviderName;
            }
            if (oConn == null || string.IsNullOrWhiteSpace(oConn.ConnectionString))
            {
                oProvider = DbProviderFactories.GetFactory(nomeProvider);
                oConn = oProvider.CreateConnection();
                oConn.ConnectionString = RetornaStringConexao();
            }
        }

        protected string RetornaStringConexao(string nomeConexaoNoConfig = "MinhaConnectionString")
        {
            return ConfigurationManager.ConnectionStrings[nomeConexaoNoConfig].ConnectionString;
        }

        protected void AbrirConexaoComBancoDados()
        {
            oConn.Open();
        }

        protected void DesconectarComBancoDados()
        {
            if (oReader != null && oReader.IsClosed)
            {
                oReader.Close();
                oReader.Dispose();
            }

            if (comando != null)
            {
                comando.Dispose();
            }

            if (oConn.State == ConnectionState.Open)
            {
                oConn.Close();
                oConn.Dispose();
            }
        }

        protected DbCommand CriarComando(string commandTextSQL = "", CommandType commandType = CommandType.Text)
        {
            oConn.ConnectionString = RetornaStringConexao();

            comando = oConn.CreateCommand();
            comando.CommandText = commandTextSQL;
            comando.CommandType = commandType;

            return comando;
        }

        protected DbParameter CriarParametro(DbCommand _comando, string nomeParametro, object valorParametro)
        {
            oParam = _comando.CreateParameter();
            oParam.ParameterName = nomeParametro;
            oParam.Value = valorParametro;
            return oParam;
        }

        protected void CriarLeitorExecutarComando(DbCommand _comando)
        {
            oReader = _comando.ExecuteReader();
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (oReader != null && oReader.IsClosed)
                    {
                        oReader.Close();
                        oReader.Dispose();
                    }

                    if (comando != null)
                    {
                        comando.Dispose();
                    }

                    if (oConn.State == ConnectionState.Open)
                    {
                        oConn.Close();
                        oConn.Dispose();
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
