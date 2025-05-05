using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
            ListarEstoque();
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
                tbtProdutos.DataSource = dt;
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
            // DateTime dateEntrada = DateTime.Parse(txtDtEntrada.Text);
            // DateTime dateValidade = DateTime.Parse(txtDtValidade.Text);
            if (!DateTime.TryParseExact(txtDtEntrada.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateEntrada))
            {
                MessageBox.Show("Data de entrada inválida. Use o formato dd/MM/yyyy.");
                return;
            }

            if (!DateTime.TryParseExact(txtDtValidade.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateValidade))
            {
                MessageBox.Show("Data de validade inválida. Use o formato dd/MM/yyyy.");
                return;
            }

            using (var conn = Conexao.Obterconexao())
            {
                string sqlCadastro = "INSERT INTO Estoque(Nome_Produto, Quantidade, Categoria,Valor_Compra, Valor_Venda, Fornecedor, Data_entrada,Validade) VALUES " +
                    " (@Nome_Produto, @Quantidade, @Categoria, @Valor_Compra, @ValorVenda, @Fornecedor, @Data_entrada, @Validade)";
                var cmd = new MySqlCommand(sqlCadastro, conn);
                cmd.Parameters.AddWithValue("@Nome_Produto", produto);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@Categoria", categoria);
                cmd.Parameters.AddWithValue("@Valor_Compra", valorCompra);
                cmd.Parameters.AddWithValue("@Valor_Venda", valorVenda);
                cmd.Parameters.AddWithValue("@Fornecedor", fornecedor);
                cmd.Parameters.AddWithValue("@Data_entrada", dateEntrada);
                cmd.Parameters.AddWithValue("@Validade", dateValidade);
                cmd.ExecuteNonQuery();
                ListarEstoque();

                MessageBox.Show("Produto cadastrado com sucesso!");



            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (tbtProdutos.CurrentRow != null)
            {


                int id = Convert.ToInt32(tbtProdutos.CurrentRow.Cells["id_produto"].Value);
                string produto = txtProduto.Text;
                int quantidade = int.Parse(txtQuantidade.Text);
                string categoria = txtCategoria.Text;
                decimal valorCompra = decimal.Parse(txtValorCompra.Text);
                decimal valorVenda = decimal.Parse(txtValorVenda.Text);
                string fornecedor = txtFornecedor.Text;
                // DateTime dateEntrada = DateTime.Parse(txtDtEntrada.Text);
                // DateTime dateValidade = DateTime.Parse(txtDtValidade.Text);
                if (!DateTime.TryParseExact(txtDtEntrada.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateEntrada))
                {
                    MessageBox.Show("Data de entrada inválida. Use o formato dd/MM/yyyy.");
                    return;
                }

                if (!DateTime.TryParseExact(txtDtValidade.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateValidade))
                {
                    MessageBox.Show("Data de validade inválida. Use o formato dd/MM/yyyy.");
                    return;
                }

                using (var conn = Conexao.Obterconexao())
                {
                    string sqlCadastro = "UPDATE Estoque SET Nome_Produto=@Nome_Produto, Quantidade=@Quantidade, Categoria=@Categoria,Valor_Compra=@Valor_Compra," +
                        " Valor_Venda=@ValorVenda, Fornecedor=@Fornecedor=@Data_entrada,Validade=@Validade WHERE id_produto=@idproduto";
                    var cmd = new MySqlCommand(sqlCadastro, conn);
                    cmd.Parameters.AddWithValue("@Nome_Produto", produto);
                    cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@Categoria", categoria);
                    cmd.Parameters.AddWithValue("@Valor_Compra", valorCompra);
                    cmd.Parameters.AddWithValue("@Valor_Venda", valorVenda);
                    cmd.Parameters.AddWithValue("@Fornecedor", fornecedor);
                    cmd.Parameters.AddWithValue("@Data_entrada", dateEntrada);
                    cmd.Parameters.AddWithValue("@Validade", dateValidade);
                    cmd.Parameters.AddWithValue("@Validade", dateValidade);
                    cmd.Parameters.AddWithValue("@idproduto", id);
                    cmd.ExecuteNonQuery();
                    ListarEstoque();

                    MessageBox.Show("Produto Atualizado com sucesso!");
                }
            }

            else
            {
                MessageBox.Show("Click na linha que deseja editar");
            }

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (tbtProdutos.CurrentRow != null)
            {
                int id = Convert.ToInt32(tbtProdutos.CurrentRow.Cells["id_produto"].Value);

                using (var conn = Conexao.Obterconexao())
                {

                    string sql = "DELETE FROM estoque WHERE id_produto = @idproduto";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@idproduto", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produto excluido com sucesso");
                    ListarEstoque();

                }
            }
        }
    }
}

