using System;
using System.Windows.Forms;
using RegrasNegocio;
using Objetos;

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
            FrmUsuarioPesquisar frmUsuarioPesquisar = new FrmUsuarioPesquisar("Funcionário");
            AbrirTela(frmUsuarioPesquisar);
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            UsuarioRegrasNegocio usuarioRegrasNegocio = new UsuarioRegrasNegocio();
            Usuario usuario = usuarioRegrasNegocio.UsuarioLogado();

            lblUsuarioNome.Text = $"Olá, {usuario.Nome}";

            if (usuario.Perfil == "Funcionário")
            {
                btnUsuarios.Visible = false;
                btnConfiguracoes.Visible = false;
            }else if (usuario.Perfil == "Consulta")
            {                
                btnEmprestimos.Visible = false;
                btnReservas.Visible = false;
                btnPagamentos.Visible = false;
                btnClientes.Visible = false;
                btnUsuarios.Visible = false;
                btnConfiguracoes.Visible = false;
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmUsuarioPesquisar frmUsuarioPesquisar = new FrmUsuarioPesquisar("Cliente");
            AbrirTela(frmUsuarioPesquisar);
        }
    }
}
