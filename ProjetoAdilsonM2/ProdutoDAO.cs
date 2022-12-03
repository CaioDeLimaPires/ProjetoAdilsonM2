using MySql.Data.MySqlClient;
using ProjetoAdilsonM2;
using System.Data;

public class ProdutoDAO
{
    public bool Cadastrar(Produto produto)
    {
        string sql_Insert = @"INSERT INTO Produto
                          (id,nome,descricao,marca,valor_unidade,material,altura,largura,quantidade,pesso)
                          VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        try
        {
            MySqlConnection conexao = ConexaoDao.Conectar();
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(sql_Insert, conexao);
            cmd.Parameters.AddWithValue("@id", produto.Id);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@marca", produto.Marca);
            cmd.Parameters.AddWithValue("@valor_Unidade", produto.ValorUn);
            cmd.Parameters.AddWithValue("@material", produto.Material);
            cmd.Parameters.AddWithValue("@altura", produto.Altura);
            cmd.Parameters.AddWithValue("@largura", produto.Largura);
            cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
            cmd.Parameters.AddWithValue("@pesso", produto.Pesso);
            cmd.ExecuteNonQuery();
            conexao.Close();
            return true;
        }
        catch (Exception erro)
        {
            if (erro.HResult == -2147467259)
            {
                MessageBox.Show("Não foi possivel cadastrar o produto!!!" +
                    "\nDetalhes:" +
                    " ESSE ID JA EXISTE", "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
    public Produto BuscarPorId(Produto id)
    {
        string sql_Select = $"SELECT * FROM produto WHERE id={id.Id}";
        try
        {
            MySqlConnection conexao = ConexaoDao.Conectar();
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(sql_Select, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string[] values =
            {
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
            //id,nome,descricao,marca,valor_unidade,material,altura,largura,quantidade,pesso
            id.Id = Convert.ToInt32(values[0]);
            id.Nome = values[1];
            id.Descricao = values[2];
            id.Marca = values[3];
            id.ValorUn = Convert.ToDouble(values[4]);
            id.Material = values[5];
            id.Altura = Convert.ToDouble(values[6]);
            id.Largura = Convert.ToDouble(values[7]);
            id.Quantidade = Convert.ToInt32(values[8]);
            id.Pesso = Convert.ToDouble(values[9]);

            return id;
        }
        catch (Exception erro)
        {
            if(erro.HResult == -2147467259)
            {
                MessageBox.Show($"Falha ao encontrar produto.\nDETALHES:(O id: {id.Id} inserido não existe!!)Tente novamente"
                    ,"ERRO!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }            
            return id;
        }
    }
    public bool Editar(Produto produto)
    {
        string sql_Update = @"UPDATE produto SET nome=@Nome,descricao=@Descricao, marca=@Marca,valor_unidade=@Valor_Unidade
        , material=@Material, altura=@Altura, largura=@Largura, quantidade=@Quantidade,pesso=@Pesso WHERE id=@Id";
        try
        {
            MySqlConnection conexao = ConexaoDao.Conectar();
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(sql_Update, conexao);
            cmd.Parameters.AddWithValue("@id", produto.Id);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@marca", produto.Marca);
            cmd.Parameters.AddWithValue("@valor_Unidade", produto.ValorUn);
            cmd.Parameters.AddWithValue("@material", produto.Material);
            cmd.Parameters.AddWithValue("@altura", produto.Altura);
            cmd.Parameters.AddWithValue("@largura", produto.Largura);
            cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
            cmd.Parameters.AddWithValue("@pesso", produto.Pesso);
            cmd.ExecuteNonQuery();
            conexao.Close();
            return true;
        }
        catch (Exception erro)
        {
            MessageBox.Show("Não foi possivel Editar o produto!!!" +
                   $"\nDetalhes:{erro}", "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
    public bool Apagar(Produto id)
    {
        string sql_Delete = @"DELETE FROM produto WHERE id=@id";
        try
        {
            MySqlConnection conexao = ConexaoDao.Conectar();
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(sql_Delete, conexao);
            cmd.Parameters.AddWithValue("@id", id.Id);
            cmd.ExecuteNonQuery();
            conexao.Close();
            return true;
        }
        catch (Exception erro)
        {
            MessageBox.Show("Não foi possivel Apagar o produto!!!" +
                  $"\nDetalhes:{erro}", "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
   
}

