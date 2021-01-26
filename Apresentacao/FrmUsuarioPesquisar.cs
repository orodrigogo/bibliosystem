using System;
using System.Data;
using System.Windows.Forms;
using RegrasNegocio;

namespace Apresentacao
{
    public partial class FrmUsuarioPesquisar : Form
    {
        string perfil = "Cliente";

        public FrmUsuarioPesquisar(string perfil)
        {
            InitializeComponent();
            this.perfil = perfil;
            lblTitulo.Text = perfil;
            cbxBuscaTipo.SelectedItem = "Nome";
            Pesquisar();
        }

        private void Pesquisar()
        {
            string valor = TxtPesquisar.Text.Trim();
            string filtro = cbxBuscaTipo.SelectedItem.ToString();

            UsuarioRegrasNegocio usuarioRegrasNegocio = new UsuarioRegrasNegocio();            
            DataTable resultado = usuarioRegrasNegocio.Pesquisar(valor, filtro, perfil);
            
            dgvDados.DataSource = resultado;            
            dgvDados.Update();
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void cbxBuscaTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
