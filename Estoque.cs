using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using PROGETOLOGIN;
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
            tbtProdutos.CellClick += tbtProdutos_CellClick; // Associa o evento
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Encerramento);
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

                // Verificar validade vencida e aplicar cor vermelha
                foreach (DataGridViewRow row in tbtProdutos.Rows)
                {
                    if (DateTime.TryParse(row.Cells["Validade"].Value?.ToString(), out DateTime validade) && validade < DateTime.Now)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red; // Marca a linha com cor vermelha
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White; // Se não estiver vencido, mantém a cor padrão
                    }
                }
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
                    MessageBox.Show("Produto excluído com sucesso.");
                    ListarEstoque();
                }
            }
        }

        private void tbtProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tbtProdutos.Rows[e.RowIndex];

                txtProduto.Text = row.Cells["Nome_Produto"].Value?.ToString();
                txtQuantidade.Text = row.Cells["Quantidade"].Value?.ToString();
                txtCategoria.Text = row.Cells["Categoria"].Value?.ToString();
                txtValorCompra.Text = row.Cells["Valor_Compra"].Value?.ToString();
                txtValorVenda.Text = row.Cells["Valor_Venda"].Value?.ToString();
                txtFornecedor.Text = row.Cells["Fornecedor"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Data_entrada"].Value?.ToString(), out DateTime dtEntrada))
                    txtDtEntrada.Text = dtEntrada.ToString("dd/MM/yyyy");

                if (DateTime.TryParse(row.Cells["Validade"].Value?.ToString(), out DateTime dtValidade))
                    txtDtValidade.Text = dtValidade.ToString("dd/MM/yyyy");
            }
        }

        private void BTNVOLTAR_Click(object sender, EventArgs e)
        {
            fORMSMENU menu = new fORMSMENU();
            menu.Show();
            this.Hide();
        }

        private void SalvarPDF_Click(object sender, EventArgs e)
        {
            // Criar um diálogo para salvar o PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Salvar Relatório em PDF";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Criando o documento PDF
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    // Abrir o documento
                    doc.Open();

                    // Adicionar título ao PDF
                    doc.Add(new Paragraph("ESTOQUE ATUAL"));
                    doc.Add(new Paragraph("\n"));

                    // Criar tabela para os dados do DataGridView
                    PdfPTable table = new PdfPTable(tbtProdutos.Columns.Count);

                    // Adicionar cabeçalhos da tabela
                    foreach (DataGridViewColumn column in tbtProdutos.Columns)
                    {
                        table.AddCell(new Phrase(column.HeaderText));
                    }

                    // Adicionar dados da DataGridView na tabela
                    foreach (DataGridViewRow row in tbtProdutos.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value?.ToString() ?? string.Empty);
                        }
                    }

                    // Adicionar a tabela no documento PDF
                    doc.Add(table);

                    // Fechar o documento
                    doc.Close();

                    MessageBox.Show("PDF gerado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o PDF: " + ex.Message);
                }
            }
        }
        private void Encerramento(object sender, FormClosingEventArgs e)
        {
            // Se o motivo do fechamento for o "X" (fechamento manual do usuário)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exibe uma caixa de mensagem perguntando se o usuário tem certeza de que quer sair
                DialogResult result = MessageBox.Show("Tem certeza de que deseja sair?",
                                                      "Confirmar saída",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                // Se o usuário clicar em "Sim", o formulário será fechado
                if (result == DialogResult.Yes)
                {
                    // Encerrando completamente a aplicação
                    Application.Exit();
                    e.Cancel = false;  // Confirma o fechamento do formulário (apesar de Application.Exit já finalizar tudo)
                }
                else
                {
                    // Caso contrário, o fechamento é cancelado
                    e.Cancel = true;
                }
            }
        }
    }
}




