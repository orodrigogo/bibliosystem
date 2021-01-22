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
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();     
        }

        private void Finalizar()
        {
            DialogResult resposta =
                        MessageBox.Show("Deseja realmente sair?", "Sair",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);


            if (resposta == DialogResult.Yes)
                Application.Exit();
        }

        private void BtnSairTopo_Click(object sender, EventArgs e)
        {
            Finalizar();
        }

        private void BtnSairMenu_Click(object sender, EventArgs e)
        {
            Finalizar();
        }

        private void AbrirTela(Form form)
        {            
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlConteudo.Controls.Clear();
            pnlConteudo.Controls.Add(form);
            form.Show();
        }

        private void BtnLivros_Click(object sender, EventArgs e)
        {
            FrmLivroPesquisar frmLivroPesquisar = new FrmLivroPesquisar();
            AbrirTela(frmLivroPesquisar);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarioCadastro frmUsuarioCadastro = new FrmUsuarioCadastro();
            AbrirTela(frmUsuarioCadastro);
        }
    }
}
