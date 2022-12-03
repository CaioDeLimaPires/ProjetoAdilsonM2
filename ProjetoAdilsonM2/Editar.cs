using MySql.Data.MySqlClient;
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
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
            //Deixa todas labels invisiveis

            lblNome.Hide();
            lblDescricao.Hide();
            lblMarca.Hide();
            lblValor.Hide();
            lblQuantidade.Hide();
            lblAltura.Hide();
            lblLargura.Hide();
            lblPesso.Hide();
            lblMaterial.Hide();

            //Deixa todas text Box invisiveis
            txtNome.Hide();
            txtDescricao.Hide();
            txtMarca.Hide();
            txtValor.Hide();
            txtMaterial.Hide();
            txtAltura.Hide();
            txtLargura.Hide();
            txtQuantidade.Hide();
            txtPesso.Hide();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Insira o Id do Produto!!!", "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Produto produto = new Produto();
                produto.Id = int.Parse(txtId.Text);
                //Construtor dos metodos
                ProdutoDAO prodDao = new ProdutoDAO();
                //Busca o Produto pelo Id
                prodDao.BuscarPorId(produto);
                if (produto.Nome != "" && produto.Descricao != "" && produto.Marca != "" && produto.ValorUn != 0)
                {
                    lblNome.Show();
                    lblDescricao.Show();
                    lblMarca.Show();
                    lblValor.Show();
                    lblQuantidade.Show();
                    lblAltura.Show();
                    lblLargura.Show();
                    lblPesso.Show();
                    lblMaterial.Show();
                    txtNome.Show();
                    txtDescricao.Show();
                    txtMarca.Show();
                    txtValor.Show();
                    txtMaterial.Show();
                    txtAltura.Show();
                    txtLargura.Show();
                    txtQuantidade.Show();
                    txtPesso.Show();

                    //Atribui os valores nas textBox
                    txtId.Text = produto.Id.ToString();
                    txtNome.Text = produto.Nome;
                    txtMarca.Text = produto.Marca;
                    txtDescricao.Text = produto.Descricao;
                    txtValor.Text = produto.ValorUn.ToString();
                    txtMaterial.Text = produto.Material;
                    txtAltura.Text = produto.Altura.ToString();
                    txtLargura.Text = produto.Largura.ToString();
                    txtQuantidade.Text = produto.Quantidade.ToString();
                    txtPesso.Text = produto.Pesso.ToString();
                    //Habilita o botão atualizar
                    btnAtualizar.Enabled = true;
                    //Deshabilita a textBox do id
                    txtId.Enabled = false;
                    //Deshabilita Btn Buscar
                    btnBuscar.Enabled = false;
                    //Habilita botão de cancelar
                    btnCancelar.Enabled = true;
                }

            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;
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

            ProdutoDAO prodDao = new ProdutoDAO();
            if (prodDao.Editar(prod))
            {
                MessageBox.Show("Dados Atualizados com sucesso!", "Atualizado!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            else
            {
                MessageBox.Show("Falha ao realizar a Edição dos dados", "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //des-Habilita o botão atualizar
            btnAtualizar.Enabled = false;
            //habilita a textBox do id
            txtId.Enabled = true;
            //Habilita o botão buscar           
            btnBuscar.Enabled = true;
            //Habilita botão de cancelar
            btnCancelar.Enabled = false;
            //Limpa as text box
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
            MessageBox.Show("Alteração cancelada", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
