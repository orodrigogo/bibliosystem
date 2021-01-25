using System;
using System.Windows.Forms;
using RegrasNegocio;
using Objetos;

namespace Apresentacao
{
    public partial class FrmUsuarioCadastro : Form
    {
        public FrmUsuarioCadastro()
        {
            InitializeComponent();
        }

        private void BtnMostrarSenha_Click(object sender, EventArgs e)
        {
            if (txtSenha.PasswordChar == '●')
            {
                txtSenha.PasswordChar = '\0';
                txtSenhaConfirmacao.PasswordChar = '\0';
                BtnMostrarSenha.Text = "Ocultar Senha";
            }
            else
            {
                txtSenha.PasswordChar = '●';
                txtSenhaConfirmacao.PasswordChar = '●';
                BtnMostrarSenha.Text = "Mostrar Senha";
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string cpfFormatado = mktCpf.Text.Replace(".", "").Replace("-", "");

                if (String.IsNullOrWhiteSpace(txtNome.Text))
                    MessageBox.Show("Digite o nome");
                else if (String.IsNullOrWhiteSpace(txtEmail.Text))
                    MessageBox.Show("Digite o e-mail");
                else if (String.IsNullOrWhiteSpace(cpfFormatado))
                    MessageBox.Show("Digite o CPF");
                else if (cbxPerfil.SelectedIndex < 0)
                    MessageBox.Show("Selecione o perfil");
                else if (String.IsNullOrWhiteSpace(txtSenha.Text))
                    MessageBox.Show("Digite a senha");
                else if (String.IsNullOrWhiteSpace(txtSenhaConfirmacao.Text))
                    MessageBox.Show("Digite a confirmação da senha");
                else if (txtSenha.Text != txtSenhaConfirmacao.Text)
                    MessageBox.Show("As senhas não são iguais");
                else
                {
                    Usuario usuario = new Usuario();
                    usuario.Nome = txtNome.Text.Trim();
                    usuario.Cpf = cpfFormatado;
                    usuario.Email = txtEmail.Text.Trim();
                    usuario.Perfil = cbxPerfil.SelectedItem.ToString();
                    usuario.Senha = txtSenha.Text.Trim();

                    UsuarioRegrasNegocio usuarioRegrasNegocio = new UsuarioRegrasNegocio();
                    usuarioRegrasNegocio.Cadastrar(usuario);
                    MessageBox.Show("Usuário cadastrado com sucesso!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
