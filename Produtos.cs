using MySql.Data.MySqlClient;
public class Produtos 
{
    public class Produto
    {
        public int ID_Produto { get; set; }            // id_produto no banco
        public string Nome_Produto { get; set; } = "";             // Nome_Produto
        public int Estoque { get; set; }               // Quantidade
        public string Categoria { get; set; }          // Categoria
        public decimal Valor_Compra { get; set; }       // Valor_Compra
        public decimal Valor_Venda { get; set; }       // Valor_Venda
        public string Fornecedor { get; set; }         // Fornecedor
        public DateTime Data_entrada { get; set; }      // Data_entrada
        public DateTime Validade { get; set; }         // Validade
    }

}
