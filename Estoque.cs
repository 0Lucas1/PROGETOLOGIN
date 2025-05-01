using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSGE
{
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ListarEstoque()
        {

            using (var conn = Conexao.Obterconexao())
            {
                string sqlEstoque = "SELECT * FROM Estoque";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlEstoque, conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string produto = txtProduto.Text;
            int quantidade = int.Parse(txtQuantidade.Text);
            string categoria = txtCategoria.Text;
            decimal valorCompra = decimal.Parse(txtValorCompra.Text);
            decimal valorVenda = decimal.Parse(txtValorVenda.Text);
            string fornecedor = txtFornecedor.Text;
            DateTime dateEntrada = DateTime.Parse(txtDtEntrada.Text);
            DateTime dateValidade = DateTime.Parse(txtDtValidade.Text);

            using (var conn = Conexao.Obterconexao())
            {
                string sqlCadastro = "INSERT INTO Estoque(Nome_Produto, Quantidade, Categoria,Valor_Compra, ValorVenda, Fornecedor, Data_entrada,Validade) VALUES (@Nome_Produto, @Quantidade, @Categoria, @Valor_Compra, @ValorVenda, @Fornecedor, @Data_entrada, @Validade)";
                var cmd = new MySqlCommand(sqlCadastro, conn);
                cmd.Parameters.AddWithValue("@Nome_Produto", produto);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@Categoria", categoria);
                cmd.Parameters.AddWithValue("@Valor_Compra", valorCompra);
                //continuar... 


            }

        }
    }
}
