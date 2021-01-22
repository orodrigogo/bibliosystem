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
    public partial class FrmLivroPesquisar : Form
    {
        public FrmLivroPesquisar()
        {
            InitializeComponent();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FrmLivroCadastro frmLivroCadastro = new FrmLivroCadastro();
            frmLivroCadastro.ShowDialog();
        }
    }
}
