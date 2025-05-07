using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Produto;




namespace PROGETOLOGIN
{
    public partial class formscaixa : Form
    {
        List<Produto> carrinho = new List<Produto>();

        public formscaixa()
        {
            InitializeComponent();
            CarregarCategorias();
            CarregarFormasPagamento();
        }

        // Carregar categorias no ComboBox
        private void CarregarCategorias()
        {
            try
            {
                cmbtipo.Items.Clear();

                using (var conn = Conexao.Obterconexao())
                {
                    string sql = "SELECT DISTINCT Categoria FROM Estoque";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbtipo.Items.Add(reader.GetString("Categoria"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco: " + ex.Message);
            }
        }

        // Carregar formas de pagamento no ComboBox
        private void CarregarFormasPagamento()
        {
            cmbFormasDePagamento.Items.Clear();
            cmbFormasDePagamento.Items.AddRange(new String[] { "DINHEIRO", "CARTÃO", "PIX" });
        }

        // Evento para buscar produtos ao clicar no botão de buscar
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbtipo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma categoria.");
                return;
            }

            string categoriaSelecionada = cmbtipo.SelectedItem.ToString();
            ProdutosDAO dao = new ProdutosDAO();
            List<Produto> produtos = dao.ListarPorCategoria(categoriaSelecionada);

            if (produtos.Count > 0)
            {
                cmbprodutos.DataSource = null;
                cmbprodutos.DataSource = produtos;
                cmbprodutos.DisplayMember = "Nome_Produto";
                cmbprodutos.ValueMember = "ID_Produto";
                cmbprodutos.Refresh();
            }
            else
            {
                MessageBox.Show("Nenhum produto encontrado para esta categoria.");
            }
        }

        // Método para atualizar o carrinho e exibir o valor total
        private void AtualizarCarrinho()
        {
            listCarrinho.Items.Clear(); // Limpar a listBox

            decimal TotalSemDesconto = 0;

            // Se o carrinho estiver vazio
            if (carrinho.Count == 0)
            {
                MessageBox.Show("Carrinho vazio!");
                lblValorTotal.Text = "Total sem desconto: R$ 0,00";
                lblValorFinal.Text = "R$ 0,00";
                lblDesconto.Text = "Sem desconto";
                return;
            }

            // Exibir os produtos no carrinho
            foreach (var item in carrinho)
            {
                listCarrinho.Items.Add($"{item.Nome_Produto} - {item.Estoque}x R$ {item.Valor_Venda:F2}"); // Adiciona na ListBox
                TotalSemDesconto += item.Estoque * item.Valor_Venda;
            }

            // Exibir o total sem desconto
            lblValorTotal.Text = $"Total sem desconto: R$ {TotalSemDesconto:F2}";

            // Aplicar o desconto, se necessário
            decimal TotalComDesconto = TotalSemDesconto;
            if (TotalComDesconto > 100)
            {
                TotalComDesconto *= 0.9M;
                lblDesconto.Text = "Desconto aplicado: 10%";
            }
            else
            {
                lblDesconto.Text = "Sem desconto";
            }

            // Exibir o valor final
            lblValorFinal.Text = $"R$ {TotalComDesconto:F2}";
        }

        // Classe para acesso aos produtos no banco de dados
        public class ProdutosDAO
        {
            public List<Produto> ListarPorCategoria(string categoria)
            {
                List<Produto> produtos = new List<Produto>();

                using (var conn = Conexao.Obterconexao())
                {
                    string sql = "SELECT id_produto, Nome_Produto, Valor_Venda, Quantidade FROM Estoque WHERE Categoria = @categoria";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    MySqlDataReader reader = cmd.ExecuteReader();

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

                return produtos;
            }
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (cmbprodutos.SelectedItem != null)
            {
                Produto prod = (Produto)cmbprodutos.SelectedItem;
                int qtd = (int)numericUpDown1.Value;

                if (qtd <= 0)
                {
                    MessageBox.Show("Por favor, insira uma quantidade válida.");
                    return;
                }

                if (qtd > prod.Estoque)
                {
                    MessageBox.Show("Quantidade indisponível em estoque.");
                    return;
                }

                // Verificar se o produto já está no carrinho
                var existente = carrinho.FirstOrDefault(p => p.ID_Produto == prod.ID_Produto);
                if (existente != null)
                {
                    // Se já estiver no carrinho, incrementar a quantidade
                    if (existente.Estoque + qtd <= prod.Estoque)
                    {
                        existente.Estoque += qtd;
                    }
                    else
                    {
                        MessageBox.Show("Quantidade total excede o estoque disponível.");
                        return;
                    }
                }
                else
                {
                    // Adicionar o produto no carrinho
                    carrinho.Add(new Produto
                    {
                        ID_Produto = prod.ID_Produto,
                        Nome_Produto = prod.Nome_Produto,
                        Valor_Venda = prod.Valor_Venda,
                        Estoque = qtd
                    });
                }

                // Mensagem de depuração para garantir que o produto foi adicionado ao carrinho
                MessageBox.Show($"Produto adicionado: {prod.Nome_Produto} - Quantidade: {qtd}");

                // Atualizar o carrinho na interface
                AtualizarCarrinho();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto.");
            }
        }

        private void BTNPAGAR_Click(object sender, EventArgs e)
        {
            if (carrinho.Count == 0)
            {
                MessageBox.Show("Carrinho vazio.");
                return;
            }

            if (cmbFormasDePagamento.SelectedItem == null)
            {
                MessageBox.Show("Selecione a forma de pagamento.");
                return;
            }

            if (!decimal.TryParse(txtValorPagamento.Text, out decimal valorPago))
            {
                MessageBox.Show("Digite um valor de pagamento válido.");
                return;
            }

            decimal valorFinal = decimal.Parse(lblValorFinal.Text.Replace("R$", "").Trim());

            if (valorPago < valorFinal)
            {
                MessageBox.Show("O valor pago é insuficiente.");
                return;
            }

            decimal troco = valorPago - valorFinal;
            lblTroco.Text = $"Troco: R$ {troco:F2}";

            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    foreach (var item in carrinho)
                    {
                        // Atualiza o estoque
                        string sqlEstoque = "UPDATE Estoque SET Quantidade = Quantidade - @quantidade WHERE id_produto = @id";
                        MySqlCommand cmdEstoque = new MySqlCommand(sqlEstoque, conn);
                        cmdEstoque.Parameters.AddWithValue("@quantidade", item.Estoque);
                        cmdEstoque.Parameters.AddWithValue("@id", item.ID_Produto);
                        cmdEstoque.ExecuteNonQuery();
                    }
                }

                // Salvar dados da venda no relatório
                using (var conn = Conexao.Obterconexao())
                {
                    foreach (var item in carrinho)
                    {
                        string insertSql = @"INSERT INTO relatorio_vendas 
                    (usuario, produto, quantidade, data_venda, valor_venda, lucro) 
                    VALUES (@usuario, @produto, @quantidade, @data_venda, @valor_venda, @lucro)";

                        MySqlCommand cmd = new MySqlCommand(insertSql, conn);
                        cmd.Parameters.AddWithValue("@usuario", LOGIN.UsuarioLogado); // usuário logado
                        cmd.Parameters.AddWithValue("@produto", item.Nome_Produto);
                        cmd.Parameters.AddWithValue("@quantidade", item.Estoque); // quantidade vendida
                        cmd.Parameters.AddWithValue("@data_venda", DateTime.Now);
                        cmd.Parameters.AddWithValue("@valor_venda", item.Valor_Venda * item.Estoque);
                        decimal lucro = (item.Valor_Venda - item.Valor_Compra) * item.Estoque;
                        cmd.Parameters.AddWithValue("@lucro", lucro);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Pagamento realizado com sucesso!");

                // Limpar interface e resetar carrinho
                carrinho.Clear();
                listCarrinho.Items.Clear();
                lblValorTotal.Text = "Total sem desconto: R$ 0,00";
                lblValorFinal.Text = "R$ 0,00";
                lblDesconto.Text = "Sem desconto";
                txtValorPagamento.Text = "";
                lblTroco.Text = "";
                cmbFormasDePagamento.SelectedIndex = -1;

                // Atualiza lista de produtos, se houver categoria selecionada
                if (cmbtipo.SelectedItem != null)
                {
                    BtnBuscar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar pagamento: " + ex.Message);
            }
        }


        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            Relatório relatorio = new Relatório();
            relatorio.ShowDialog();
        }
    }
}

















