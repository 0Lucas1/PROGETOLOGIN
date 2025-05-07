using MySql.Data.MySqlClient;
using static Produto;

public class ProdutosDAO
{

    public List<string> ListarCategorias()
    {
        List<string> categorias = new List<string>();
        using (var conn = Conexao.Obterconexao())
        {
            string sql = "SELECT DISTINCT Categoria FROM Estoque";
            using (var cmd = new MySqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    categorias.Add(reader.GetString("Categoria"));
                }
            }
        }
        return categorias;
    }
    public List<Produto> ListarPorCategoria(string categoria)
    {
        List<Produto> produtos = new List<Produto>();

        try
        {
            using (var conn = Conexao.Obterconexao())
            {
                // Verifique se a conexão foi aberta
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Conexão com o banco de dados bem-sucedida!");
                }

                string sql = "SELECT id_produto, Nome_Produto, Valor_Venda, Quantidade FROM Estoque WHERE Categoria = @categoria";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@categoria", categoria);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("Nenhum produto encontrado na categoria.");
                }
                else
                {
                    while (reader.Read())
                    {
                        produtos.Add(new Produto()
                        {
                            ID_Produto = reader.GetInt32("id_produto"),
                            Nome_Produto = reader.GetString("Nome_Produto"),
                            Valor_Venda = reader.GetDecimal("Valor_Venda"),
                            Estoque = reader.GetInt32("Quantidade")
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao buscar produtos: " + ex.Message);
        }

        return produtos;
    }




}

