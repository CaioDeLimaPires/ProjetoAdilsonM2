
using MySql.Data.MySqlClient;

public class ConexaoDao
{
    private MySqlConnection conn;
    private static String Host = "Localhost";
    private static String Username = "root";
    private static String Password = "";
    private static String DbName = "ProjetoM2";

    public static MySqlConnection Conectar()
    {
        string conexao = $"datasource={Host};username={Username};password={Password};database={DbName}";
       return new MySqlConnection(conexao);
    }
}

