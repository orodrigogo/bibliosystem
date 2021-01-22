using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(txtSenha.PasswordChar == '●')
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
    }
}
