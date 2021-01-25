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
            try
            {
                UsuarioRegrasNegocio usuarioRegrasNegocio = new UsuarioRegrasNegocio();
                usuarioRegrasNegocio.Entrar(txtEmail.Text, txtSenha.Text);

                FrmHome frmHome = new FrmHome();
                frmHome.Show();
                Hide();
            }catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
