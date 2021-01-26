using System;
using System.Windows.Forms;
using RegrasNegocio;
using Objetos;

namespace Apresentacao
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void LblFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            Entrar();
        }

        private void Entrar()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtEmail.Text))
                    MessageBox.Show("Digite o e-mail");
                else if
                    (String.IsNullOrWhiteSpace(txtSenha.Text))
                    MessageBox.Show("Digite a senha");
                else
                {
                    UsuarioRegrasNegocio usuarioRegrasNegocio = new UsuarioRegrasNegocio();
                    usuarioRegrasNegocio.Entrar(txtEmail.Text, txtSenha.Text);

                    FrmHome frmHome = new FrmHome();
                    frmHome.Show();
                    Hide();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Entrar();
        }
    }
}
