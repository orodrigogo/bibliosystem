using System;
using Objetos;
using AcessoDados;
using System.Data;
using System.Data.SqlClient;

namespace RegrasNegocio
{
    public class UsuarioRegrasNegocio
    {
        public string Cadastrar(Usuario usuario)
        {
            try
            {
                AcessoDadosSQLServer acessoDadosSQLServer = new AcessoDadosSQLServer();
                SqlCommand sqlCommand = new SqlCommand("sp_usuario_cadastrar", acessoDadosSQLServer.Conectar());
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@cpf", usuario.Cpf);
                sqlCommand.Parameters.AddWithValue("@nome", usuario.Nome);
                sqlCommand.Parameters.AddWithValue("@email", usuario.Email);
                sqlCommand.Parameters.AddWithValue("@senha", usuario.Senha);
                sqlCommand.Parameters.AddWithValue("@perfil", usuario.Perfil);

                return sqlCommand.ExecuteScalar().ToString();

            }catch(Exception erro)
            {
                throw new Exception(erro.Message);
            }         
        }

        public Usuario Entrar(string email, string senha)
        {
            try
            {
                AcessoDadosSQLServer acessoDadosSQLServer = new AcessoDadosSQLServer();
                SqlCommand sqlCommand = new SqlCommand("sp_login", acessoDadosSQLServer.Conectar());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                
                sqlCommand.Parameters.AddWithValue("@email", email.Trim());
                sqlCommand.Parameters.AddWithValue("@senha", senha.Trim());

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                    throw new Exception("E-mail ou senha inválido");

                Usuario usuario = new Usuario();
                usuario.Cpf = dataTable.Rows[0]["cpf"].ToString();
                usuario.Nome = dataTable.Rows[0]["nome"].ToString();
                usuario.Email = dataTable.Rows[0]["email"].ToString();
                usuario.Perfil = dataTable.Rows[0]["perfil"].ToString();

                // Salvar os dados do usuário nas configs globais para utilizar em qualquer lugar.

                return usuario;                
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}

