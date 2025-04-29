using MySql.Data.MySqlClient;
public static class Conexao 
{
    public static MySqlConnection Obterconexao() 
    {
        string conexaoString = "server=localhost;database=login;uid=root;pwd=senacJBQ;port=3307";

        var conexao = new MySqlConnection(conexaoString);
        conexao.Open();
        return conexao;
    }


}
