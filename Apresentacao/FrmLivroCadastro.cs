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
    public partial class FrmLivroCadastro : Form
    {
        public FrmLivroCadastro()
        {
            InitializeComponent();
        }

        private void BtnAutorAdicionar_Click(object sender, EventArgs e)
        {
            string autorNome = txtAutorNome.Text;
            string autorSobrenome = txtAutorSobrenome.Text;

            if (String.IsNullOrWhiteSpace(autorNome))
            {
                MessageBox.Show("Digite o nome do autor!");
                txtAutorNome.Focus();
            }else if (String.IsNullOrWhiteSpace(autorSobrenome))
            {
                MessageBox.Show("Digite o sobrenome do autor!");
                txtAutorSobrenome.Focus();
            }
            else
            {
                MessageBox.Show("Está tudo certo!");
            }

        }

        private void TxtSobre_TextChanged(object sender, EventArgs e)
        {
            int caracteres = txtSobre.Text.Length;
            lblSobreCaracteres.Text = $"{caracteres}/200";

            if (caracteres == 200)
                lblSobreCaracteres.ForeColor = Color.Red;
            else
                lblSobreCaracteres.ForeColor = Color.Gray;
        }
    }
}
