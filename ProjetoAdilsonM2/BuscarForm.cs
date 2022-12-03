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
    public partial class BuscarForm : Form
    {
        public BuscarForm()
        {
            InitializeComponent();
            listView1.View = View.Details;
            //id,nome,descricao,marca,valor_unidade,material,altura,largura,quantidade,pesso
            listView1.Columns.Add("ID", 30, HorizontalAlignment.Left);
            listView1.Columns.Add("Nome", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Descrição", 170, HorizontalAlignment.Left);
            listView1.Columns.Add("Marca", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("ValorUnidade", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Material", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Altura", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Largura", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Quantidade", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Pesso", 100, HorizontalAlignment.Left);
        }

        private void BuscarForm_Load(object sender, EventArgs e)
        {
           

            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string sql_Select = "SELECT * FROM Produto";
            try
            {
                MySqlConnection conn = ConexaoDao.Conectar();
                // Executar Comando select
                MySqlCommand comand = new MySqlCommand(sql_Select, conn);
                //abre a conexão
                conn.Open();
                MySqlDataReader reader = comand.ExecuteReader();

                // limpa o listview
                listView1.Items.Clear();
                // Adiciona as linhas ao list view com os dados do banco
                while (reader.Read())
                {
                    string[] row =
                    {
                        //recebe os dados do banco
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8),
                        reader.GetString(9)
                    };
                    // Adiciona as linhas ao list view com os dados do banco
                    var linhaLista = new ListViewItem(row);
                    listView1.Items.Add(linhaLista);                    
                }

            }
            catch (Exception erro) 
            {
                MessageBox.Show("Falha ao realizar Busca", "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
