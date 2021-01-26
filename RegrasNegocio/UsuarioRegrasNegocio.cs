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

        public void Entrar(string email, string senha)
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


                Properties.Settings.Default.usuarioNome = dataTable.Rows[0]["nome"].ToString();
                Properties.Settings.Default.usuarioEmail = dataTable.Rows[0]["email"].ToString();
                Properties.Settings.Default.usuarioPerfil = dataTable.Rows[0]["perfil"].ToString();
                Properties.Settings.Default.Save();                                        
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public Usuario UsuarioLogado()
        {
            Usuario usuario = new Usuario();
            usuario.Nome = Properties.Settings.Default.usuarioNome;
            usuario.Email = Properties.Settings.Default.usuarioEmail;
            usuario.Perfil = Properties.Settings.Default.usuarioPerfil;

            return usuario;
        }

        public DataTable Pesquisar(string valor, string filtro, string perfil)
        {
            try
            {
                AcessoDadosSQLServer acessoDadosSQLServer = new AcessoDadosSQLServer();
                SqlCommand sqlCommand = new SqlCommand("sp_usuario_pesquisar", acessoDadosSQLServer.Conectar());
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@valor", valor);
                sqlCommand.Parameters.AddWithValue("@filtro", filtro);
                sqlCommand.Parameters.AddWithValue("@perfil", perfil);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}

