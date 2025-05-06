using MySql.Data.MySqlClient;
using static Produtos;

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
        List<Produto> produtos = new List<Produto>();  // Alterado de 'Produtos' para 'Produto'

        using (var conn = Conexao.Obterconexao())
        {
            string sql = "SELECT id_produto, Nome_Produto, Valor_Venda, Quantidade FROM Estoque WHERE Categoria = @categoria";

            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@categoria", categoria);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produtos.Add(new Produto()  // Alterado de 'Produtos' para 'Produto'
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

        return produtos;
    }


}

