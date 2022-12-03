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
    public partial class ApagarForm : Form
    {
        public ApagarForm()
        {
            InitializeComponent();
        }

        private void btbApagar_Click(object sender, EventArgs e)
        {
            Produto prod = new Produto();
            prod.Id = int.Parse(txtId.Text);
            ProdutoDAO produtoDAO = new ProdutoDAO();
            produtoDAO.BuscarPorId(prod);
            if (prod.Nome != null)
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show($"Você realmente deseja apagar o Produto ({prod.Nome})", "Confirmação!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    produtoDAO.Apagar(prod);
                    MessageBox.Show("Produto apaga com sucesso!!!", "Apagado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                btbApagar.Enabled = true;
            }
            else
            {
                btbApagar.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProduto form = new FormProduto();
            form.ShowDialog();
        }
    }
}
