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
    public partial class CadastrarForm : Form
    {
        public CadastrarForm()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Produto prod = new Produto();
            prod.Id = int.Parse(txtId.Text);
            prod.Nome = txtNome.Text;
            prod.Descricao = txtDescricao.Text;
            prod.Marca = txtMarca.Text;
            prod.Quantidade = int.Parse(txtQuantidade.Text);
            prod.Material = txtMaterial.Text;
            prod.Altura = double.Parse(txtAltura.Text);
            prod.Largura = double.Parse(txtLargura.Text);
            prod.ValorUn = double.Parse(txtValor.Text);
            prod.Pesso = double.Parse(txtPesso.Text);
            if (txtId.Text != "" && txtNome.Text != "" && txtDescricao.Text != "" && txtMarca.Text != "" && txtValor.Text != "")
            {
                btnCadastrar.Enabled = true;
                ProdutoDAO produto = new ProdutoDAO();
                if (produto.Cadastrar(prod))
                {
                    MessageBox.Show("Dados cadastrados com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtId.Clear();
                    txtNome.Clear();
                    txtDescricao.Clear();
                    txtMarca.Clear();
                    txtQuantidade.Clear();
                    txtMaterial.Clear();
                    txtAltura.Clear();
                    txtLargura.Clear();
                    txtValor.Clear();
                    txtPesso.Clear();
                    btnCadastrar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Falha ao realizar cadastro", "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProduto form = new FormProduto();
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
