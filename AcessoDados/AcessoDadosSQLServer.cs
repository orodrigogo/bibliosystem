using System;
using System.Data.SqlClient;
using System.Data;

namespace AcessoDados
{
    public class AcessoDadosSQLServer
    {
        SqlConnection conexao = null;

        public SqlConnection Conectar()
        {
            try
            {
                string parametros = @"Data Source=BEB0580624W10-1\SQLEXPRESS;Initial Catalog=bibliosystem;User ID=sa;Password=sa";
                conexao = new SqlConnection(parametros);

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                return conexao;
            }
            catch(Exception erro)
            {
                conexao.Close();
                throw erro;                
            }
        }

        public void Fechar()
        {
            conexao.Close();
        }
    }
}
