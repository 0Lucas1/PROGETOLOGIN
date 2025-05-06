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

            if (string.IsNullOrWhiteSpace(txtProduto.Text) ||
        string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
        string.IsNullOrWhiteSpace(txtCategoria.Text) ||
        string.IsNullOrWhiteSpace(txtValorCompra.Text) ||
        string.IsNullOrWhiteSpace(txtValorVenda.Text) ||
        string.IsNullOrWhiteSpace(txtFornecedor.Text) ||
        string.IsNullOrWhiteSpace(txtDtEntrada.Text) ||
        string.IsNullOrWhiteSpace(txtDtValidade.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de continuar.");
                return;
            }

            string produto = txtProduto.Text;

            if (!int.TryParse(txtQuantidade.Text, out int quantidade))
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            string categoria = txtCategoria.Text;

            if (!decimal.TryParse(txtValorCompra.Text, out decimal valorCompra))
            {
                MessageBox.Show("Valor de compra inválido.");
                return;
            }

            if (!decimal.TryParse(txtValorVenda.Text, out decimal valorVenda))
            {
                MessageBox.Show("Valor de venda inválido.");
                return;
            }

            string fornecedor = txtFornecedor.Text;

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

            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    string sqlCadastro = "INSERT INTO Estoque(Nome_Produto, Quantidade, Categoria, Valor_Compra, Valor_Venda, Fornecedor, Data_entrada, Validade) " +
                                         "VALUES (@Nome_Produto, @Quantidade, @Categoria, @Valor_Compra, @Valor_Venda, @Fornecedor, @Data_entrada, @Validade)";

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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + ex.Message);
            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {


            if (tbtProdutos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto para atualizar.");
                return;
            }

            int id = Convert.ToInt32(tbtProdutos.CurrentRow.Cells["id_produto"].Value);

            if (string.IsNullOrWhiteSpace(txtProduto.Text) ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtValorCompra.Text) ||
                string.IsNullOrWhiteSpace(txtValorVenda.Text) ||
                string.IsNullOrWhiteSpace(txtFornecedor.Text) ||
                string.IsNullOrWhiteSpace(txtDtEntrada.Text) ||
                string.IsNullOrWhiteSpace(txtDtValidade.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de continuar.");
                return;
            }

            string produto = txtProduto.Text;

            if (!int.TryParse(txtQuantidade.Text, out int quantidade))
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            string categoria = txtCategoria.Text;

            if (!decimal.TryParse(txtValorCompra.Text, out decimal valorCompra))
            {
                MessageBox.Show("Valor de compra inválido.");
                return;
            }

            if (!decimal.TryParse(txtValorVenda.Text, out decimal valorVenda))
            {
                MessageBox.Show("Valor de venda inválido.");
                return;
            }

            string fornecedor = txtFornecedor.Text;

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

            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    string sqlUpdate = "UPDATE Estoque SET Nome_Produto = @Nome_Produto, Quantidade = @Quantidade, Categoria = @Categoria, " +
                        "Valor_Compra = @Valor_Compra, Valor_Venda = @Valor_Venda, Fornecedor = @Fornecedor, " +
                        "Data_entrada = @Data_entrada, Validade = @Validade WHERE id_produto = @id";

                    var cmd = new MySqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@Nome_Produto", produto);
                    cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@Categoria", categoria);
                    cmd.Parameters.AddWithValue("@Valor_Compra", valorCompra);
                    cmd.Parameters.AddWithValue("@Valor_Venda", valorVenda);
                    cmd.Parameters.AddWithValue("@Fornecedor", fornecedor);
                    cmd.Parameters.AddWithValue("@Data_entrada", dateEntrada);
                    cmd.Parameters.AddWithValue("@Validade", dateValidade);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    ListarEstoque();

                    MessageBox.Show("Produto atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
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

