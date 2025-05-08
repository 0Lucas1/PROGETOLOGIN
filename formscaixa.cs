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
            lblTroco.Text = troco >= 0 ? $"Troco: R$ {troco:F2}" : "Valor insuficiente para pagamento.";

            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    using (var transaction = conn.BeginTransaction()) // Inicia uma transação para garantir a integridade dos dados
                    {
                        foreach (var item in carrinho)
                        {
                            // Obter o nome do produto
                            string nomeProdutoQuery = "SELECT Nome_Produto FROM Estoque WHERE ID_Produto = @id_produto";
                            MySqlCommand cmdNomeProduto = new MySqlCommand(nomeProdutoQuery, conn);
                            cmdNomeProduto.Parameters.AddWithValue("@id_produto", item.ID_Produto);
                            string nomeProduto = cmdNomeProduto.ExecuteScalar()?.ToString();

                            if (string.IsNullOrEmpty(nomeProduto)) // Verifica se o produto foi encontrado
                            {
                                MessageBox.Show("Produto não encontrado no banco de dados.");
                                return;
                            }

                            // Obter o nome do usuário logado (somente da tabela 'Usuarios')
                            string nomeUsuarioQuery = "SELECT Usuario FROM Usuarios WHERE ID = @id_usuario";
                            MySqlCommand cmdNomeUsuario = new MySqlCommand(nomeUsuarioQuery, conn);
                            cmdNomeUsuario.Parameters.AddWithValue("@id_usuario", LOGIN.IDUsuarioLogado);
                            string nomeUsuario = cmdNomeUsuario.ExecuteScalar()?.ToString();

                            if (string.IsNullOrEmpty(nomeUsuario)) // Verifica se o usuário foi encontrado
                            {
                                MessageBox.Show("Usuário não encontrado ou inválido.");
                                return;
                            }

                            // Comando para inserir a venda na tabela 'vendas'
                            string insertSql = @"INSERT INTO vendas 
                    (ID_Produto, Quantidade, Valor_Total, Data_Venda, ID_Usuario) 
                    VALUES (@id_produto, @quantidade, @valor_total, @data_venda, @id_usuario)";

                            MySqlCommand cmd = new MySqlCommand(insertSql, conn);
                            cmd.Parameters.AddWithValue("@id_produto", item.ID_Produto);
                            cmd.Parameters.AddWithValue("@quantidade", item.Estoque);
                            cmd.Parameters.AddWithValue("@valor_total", item.Valor_Venda * item.Estoque);
                            cmd.Parameters.AddWithValue("@data_venda", DateTime.Now);
                            cmd.Parameters.AddWithValue("@id_usuario", LOGIN.IDUsuarioLogado);
                            cmd.ExecuteNonQuery(); // Registra a venda

                            // Baixar o estoque após a venda
                            string updateEstoqueSql = @"UPDATE Estoque 
                                                SET Quantidade = Quantidade - @quantidade
                                                WHERE ID_Produto = @id_produto";

                            MySqlCommand cmdUpdateEstoque = new MySqlCommand(updateEstoqueSql, conn);
                            cmdUpdateEstoque.Parameters.AddWithValue("@quantidade", item.Estoque);
                            cmdUpdateEstoque.Parameters.AddWithValue("@id_produto", item.ID_Produto);
                            cmdUpdateEstoque.ExecuteNonQuery(); // Atualiza o estoque

                            // (Opcional) Log no console
                            Console.WriteLine($"Venda registrada: {nomeProduto} vendida por {nomeUsuario}");
                        }

                        transaction.Commit(); // Se todas as vendas forem inseridas com sucesso, comita a transação
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

                    // Atualiza lista de produtos se houver categoria selecionada
                    if (cmbtipo.SelectedItem != null)
                    {
                        BtnBuscar_Click(null, null);
                    }
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


        private void btnVerCaixa_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Conexão com o banco de dados
                using (var conn = Conexao.Obterconexao())
                {
                    // Consulta SQL para calcular o faturamento e lucro
                    string queryCaixa = @"
                SELECT SUM(v.quantidade * e.Valor_Venda) AS Faturamento,
                       SUM((e.Valor_Venda - e.Valor_Compra) * v.quantidade) AS Lucro
                FROM vendas v
                JOIN Estoque e ON v.ID_Produto = e.ID_Produto";

                    MySqlCommand cmdCaixa = new MySqlCommand(queryCaixa, conn);
                    MySqlDataReader reader = cmdCaixa.ExecuteReader();

                    if (reader.Read())
                    {
                        decimal faturamento = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                        decimal lucro = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);

                        // Exibir os valores de Caixa, Faturamento e Lucro na MessageBox
                        MessageBox.Show($"Caixa Atual: R$ {faturamento:C}\nFaturamento Total: R$ {faturamento:C}\nLucro Acumulado: R$ {lucro:C}",
                                        "Informações do Caixa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Não há vendas registradas para mostrar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }
    }
}

















