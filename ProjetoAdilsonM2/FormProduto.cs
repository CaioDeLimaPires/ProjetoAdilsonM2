using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAdilsonM2
{
    public partial class FormProduto : Form
    {
        public FormProduto()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarForm form = new CadastrarForm();
            form.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            BuscarForm form = new BuscarForm();
            form.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar form = new Editar();
            form.ShowDialog();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ApagarForm form = new ApagarForm();
            form.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
