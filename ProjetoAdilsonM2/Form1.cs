namespace ProjetoAdilsonM2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduto form = new FormProduto();
            form.MdiParent = this;
            form.Show();
        }
    }
}