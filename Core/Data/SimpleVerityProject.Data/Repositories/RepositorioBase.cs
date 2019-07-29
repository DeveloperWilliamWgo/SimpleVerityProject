using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace SimpleVerityProject.Data
{
    public abstract class RepositorioBase<Entidade, RepositorioEntidade> : MarshalByRefObject
        where Entidade : class
        where RepositorioEntidade : class
    {
        protected static DbCommand comando;
        protected static DbConnection oConn;
        protected static DbProviderFactory oProvider;
        protected static DbDataReader oReader;
        protected static DbParameter oParam;
        
        public RepositorioBase() : this("")
        {
        }

        public RepositorioBase(string nomeProvider)
        {
            if (string.IsNullOrEmpty(nomeProvider))
            {
                nomeProvider = ConfigurationManager.ConnectionStrings["MinhaConnectionString"].ProviderName;
            }
            try
            {
                if (oConn == null || string.IsNullOrEmpty(oConn.ConnectionString))
                {
                    oProvider = DbProviderFactories.GetFactory(nomeProvider);
                    oConn = oProvider.CreateConnection();
                    oConn.ConnectionString = RetornaStringConexao();
                }
            }
            catch (NullReferenceException)
            {
                throw new Exception("String de conexão informada não existe no arquivo de configuração.");
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
            if (oReader != null && oReader.IsClosed == false)
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
    }
}
