using MySql.Data.MySqlClient;
public static class Conexao 
{
    public static MySqlConnection Obterconexao() 
    {
        string conexaoString = "server=localhost;database=sge;uid=root;pwd=senacJBQ;port=3307";
       //string conexaoString = "server=localhost;database=sge;uid=root;pwd=@LuCaS109;port=3306";

        var conexao = new MySqlConnection(conexaoString);
        conexao.Open();
        return conexao;
    }


}
