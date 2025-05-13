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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Encerramento);
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
            // Limpar a listBox para garantir que não haja itens antigos
            listCarrinho.Items.Clear();

            // Variável para calcular o total sem desconto
            decimal TotalSemDesconto = 0;

            // Verificar se o carrinho está vazio
            if (carrinho.Count == 0)
            {
                MessageBox.Show("Carrinho vazio!");
                lblValorTotal.Text = "Total sem desconto: R$ 0,00";
                lblValorFinal.Text = "R$ 0,00";
                return;
            }

            // Exibir os produtos no carrinho
            foreach (var item in carrinho)
            {
                // Adiciona o produto na listBox com o nome, quantidade e preço
                listCarrinho.Items.Add($"{item.Nome_Produto} - {item.Estoque}x R$ {item.Valor_Venda:F2}");

                // Calcular o total sem desconto
                TotalSemDesconto += item.Estoque * item.Valor_Venda;
            }

            // Exibir o total sem desconto na label
            lblValorTotal.Text = $"Total sem desconto: R$ {TotalSemDesconto:F2}";

            // Exibir o valor final (por enquanto sem desconto)
            lblValorFinal.Text = $"R$ {TotalSemDesconto:F2}";
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
            // Verificar se o caixa está aberto
            using (var conn = Conexao.Obterconexao())
            {
                string queryCaixaAberto = "SELECT COUNT(*) FROM caixa WHERE status = 'Aberto'";
                MySqlCommand cmdCheckCaixa = new MySqlCommand(queryCaixaAberto, conn);
                int caixaAbertoCount = Convert.ToInt32(cmdCheckCaixa.ExecuteScalar());

                if (caixaAbertoCount == 0)
                {
                    MessageBox.Show("Nenhum caixa está aberto. Por favor, abra um caixa antes de realizar o pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Se o caixa não estiver aberto, interrompe o pagamento
                }
            }

            // Continuação do código de pagamento...
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
                using (var conn = Conexao.Obterconexao())
                {
                    // Obter o nome do usuário logado (somente da tabela 'Usuarios')
                    string nomeUsuarioQuery = "SELECT Usuario FROM Usuarios WHERE ID = @id_usuario";
                    MySqlCommand cmdNomeUsuario = new MySqlCommand(nomeUsuarioQuery, conn);
                    cmdNomeUsuario.Parameters.AddWithValue("@id_usuario", LOGIN.IDUsuarioLogado); // ID do usuário logado
                    string nomeUsuario = cmdNomeUsuario.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(nomeUsuario)) // Verifica se o usuário foi encontrado
                    {
                        MessageBox.Show("Usuário não encontrado ou inválido.");
                        return;
                    }

                    // Consulta para obter a data de abertura do último caixa aberto
                    string queryCaixaAberto = @"
        SELECT ID_Caixa, Data_Abertura 
        FROM caixa 
        WHERE status = 'Aberto' 
        ORDER BY Data_Abertura DESC 
        LIMIT 1";

                    MySqlCommand cmdCaixaAberto = new MySqlCommand(queryCaixaAberto, conn);
                    MySqlDataReader readerCaixa = cmdCaixaAberto.ExecuteReader();

                    DateTime dataAbertura;

                    if (readerCaixa.Read())
                    {
                        dataAbertura = readerCaixa.GetDateTime("Data_Abertura");
                    }
                    else
                    {
                        // Nenhum caixa aberto encontrado
                        MessageBox.Show("Nenhum caixa aberto encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    readerCaixa.Close();

                    // Agora buscar faturamento e lucro das vendas feitas após a abertura do caixa
                    string queryValores = @"
        SELECT 
            SUM(v.quantidade * e.Valor_Venda) AS Faturamento,
            SUM((e.Valor_Venda - e.Valor_Compra) * v.quantidade) AS Lucro
        FROM vendas v
        JOIN Estoque e ON v.ID_Produto = e.ID_Produto
        WHERE v.Data_Venda >= @dataAbertura";

                    MySqlCommand cmdValores = new MySqlCommand(queryValores, conn);
                    cmdValores.Parameters.AddWithValue("@dataAbertura", dataAbertura);

                    decimal faturamento = 0;
                    decimal lucro = 0;

                    using (MySqlDataReader readerValores = cmdValores.ExecuteReader())
                    {
                        if (readerValores.Read())
                        {
                            faturamento = readerValores.IsDBNull(0) ? 0 : readerValores.GetDecimal(0);
                            lucro = readerValores.IsDBNull(1) ? 0 : readerValores.GetDecimal(1);
                        }
                    }

                    // Exibir as informações do caixa
                    MessageBox.Show($"Caixa Aberto Desde: {dataAbertura}\n" +
                                    $"Faturamento: R$ {faturamento:C}\n" +
                                    $"Lucro: R$ {lucro:C}\n" +
                                    $"Usuário Logado: {nomeUsuario}",
                                    "Informações do Caixa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Pergunta ao usuário se ele deseja realmente fechar o caixa
                DialogResult dialogResult = MessageBox.Show("Você tem certeza que deseja fechar o caixa?", "Fechar Caixa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    // Se o usuário escolher "Não", o processo é interrompido
                    return;
                }

                // Conexão com o banco de dados
                using (var conn = Conexao.Obterconexao())
                {
                    // Verificar se existe um caixa aberto
                    string queryCaixaAberto = "SELECT COUNT(*) FROM caixa WHERE status = 'Aberto' ORDER BY Data_Abertura DESC LIMIT 1";
                    MySqlCommand cmdCaixaAberto = new MySqlCommand(queryCaixaAberto, conn);
                    int caixaAberto = Convert.ToInt32(cmdCaixaAberto.ExecuteScalar());

                    if (caixaAberto == 0)
                    {
                        // Se não houver caixa aberto, exibe uma mensagem de erro
                        MessageBox.Show("Não há caixa aberto para ser fechado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Consultar o faturamento e lucro
                    string queryCaixa = @"
            SELECT SUM(v.quantidade * e.Valor_Venda) AS Faturamento,
                   SUM((e.Valor_Venda - e.Valor_Compra) * v.quantidade) AS Lucro
            FROM vendas v
            JOIN Estoque e ON v.ID_Produto = e.ID_Produto
            WHERE v.Data_Venda >= (SELECT Data_Abertura FROM caixa WHERE status = 'Aberto' ORDER BY Data_Abertura DESC LIMIT 1)";

                    MySqlCommand cmdCaixa = new MySqlCommand(queryCaixa, conn);
                    MySqlDataReader reader = cmdCaixa.ExecuteReader();

                    decimal faturamento = 0;
                    decimal lucro = 0;

                    if (reader.Read())
                    {
                        faturamento = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                        lucro = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                    }
                    reader.Close();

                    // Atualizar o status do caixa para 'Fechado' e inserir os valores do fechamento
                    string queryFecharCaixa = @"
            UPDATE caixa 
            SET status = 'Fechado', 
                Data_Fechamento = @Data_Fechamento, 
                Saldo = @Saldo, 
                Faturamento = @Faturamento, 
                Lucro = @Lucro 
            WHERE status = 'Aberto'";

                    MySqlCommand cmdFecharCaixa = new MySqlCommand(queryFecharCaixa, conn);
                    cmdFecharCaixa.Parameters.AddWithValue("@Data_Fechamento", DateTime.Now); // Data e Hora do fechamento
                    cmdFecharCaixa.Parameters.AddWithValue("@Saldo", faturamento); // O saldo é o faturamento
                    cmdFecharCaixa.Parameters.AddWithValue("@Faturamento", faturamento);
                    cmdFecharCaixa.Parameters.AddWithValue("@Lucro", lucro);

                    // Executa o fechamento do caixa
                    cmdFecharCaixa.ExecuteNonQuery();

                    // Exibe mensagem de sucesso
                    MessageBox.Show("Caixa fechado e registrado com sucesso!", "Fechamento de Caixa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void btnabrircaixa_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    // Obter o nome do usuário logado corretamente
                    string nomeUsuarioQuery = "SELECT Usuario FROM Usuarios WHERE ID = @id_usuario";
                    MySqlCommand cmdNomeUsuario = new MySqlCommand(nomeUsuarioQuery, conn);
                    cmdNomeUsuario.Parameters.AddWithValue("@id_usuario", LOGIN.IDUsuarioLogado); // ID do usuário logado (do login)

                    // Executa a consulta e obtém o nome do usuário
                    string nomeUsuario = cmdNomeUsuario.ExecuteScalar()?.ToString();

                    // Verifica se o nome do usuário foi encontrado
                    if (string.IsNullOrEmpty(nomeUsuario)) // Se o nome não for encontrado, exibe erro
                    {
                        MessageBox.Show("Usuário não encontrado ou inválido.");
                        return;
                    }

                    // Verificar se já existe um caixa aberto
                    string queryCheck = "SELECT COUNT(*) FROM caixa WHERE status = 'Aberto'";
                    MySqlCommand cmdCheck = new MySqlCommand(queryCheck, conn);
                    int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (count == 0)
                    {
                        DateTime dataAbertura = DateTime.Now;

                        // Insere o novo caixa como aberto
                        string queryInsert = @"
            INSERT INTO caixa 
            (Status, Data_Abertura, Saldo, Faturamento, Lucro, Usuario_Abertura) 
            VALUES 
            ('Aberto', @DataAbertura, 0, 0, 0, @Usuario)";

                        MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conn);
                        cmdInsert.Parameters.AddWithValue("@DataAbertura", dataAbertura);
                        cmdInsert.Parameters.AddWithValue("@Usuario", nomeUsuario); // Nome do usuário logado
                        cmdInsert.ExecuteNonQuery();

                        // Consulta o faturamento e lucro a partir desse momento (por enquanto será zero)
                        decimal faturamento = 0;
                        decimal lucro = 0;

                        string queryLucro = @"
            SELECT 
                SUM(v.quantidade * e.Valor_Venda) AS Faturamento,
                SUM((e.Valor_Venda - e.Valor_Compra) * v.quantidade) AS Lucro
            FROM vendas v
            JOIN Estoque e ON v.ID_Produto = e.ID_Produto
            WHERE v.Data_Venda >= @DataAbertura";

                        MySqlCommand cmdLucro = new MySqlCommand(queryLucro, conn);
                        cmdLucro.Parameters.AddWithValue("@DataAbertura", dataAbertura);

                        using (MySqlDataReader reader = cmdLucro.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                faturamento = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                                lucro = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                            }
                        }

                        MessageBox.Show(
                            $"Caixa aberto com sucesso!\n\n" +
                            $"Data de Abertura: {dataAbertura}\n" +
                            $"Usuário: {nomeUsuario}\n" +
                            $"Faturamento Atual: R$ {faturamento:C}\n" +
                            $"Lucro Atual: R$ {lucro:C}",
                            "Caixa Aberto", MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show("Já existe um caixa aberto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir o caixa: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Itera de trás pra frente para evitar problemas de índice ao remover
            for (int i = listCarrinho.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = listCarrinho.SelectedIndices[i];

                // Remove da lista visual (ListBox)
                listCarrinho.Items.RemoveAt(index);

                // Remove da lista lógica (carrinho)
                carrinho.RemoveAt(index);
            }

            // Atualiza os valores depois da remoção
            AtualizarCarrinho(); // Chama o método que recalcula total e atualiza labels
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            // Verificar se o carrinho está vazio
            if (carrinho.Count == 0)
            {
                MessageBox.Show("Carrinho vazio!");
                return;
            }

            // Calcular o total sem desconto
            decimal TotalSemDesconto = 0;
            foreach (var item in carrinho)
            {
                TotalSemDesconto += item.Estoque * item.Valor_Venda;
            }

            // Exibir o total sem desconto
            lblValorTotal.Text = $"Total sem desconto: R$ {TotalSemDesconto:F2}";

            // Obter o valor do desconto em porcentagem
            if (decimal.TryParse(txtDesconto.Text, out decimal descontoPercentual))
            {
                // Verificar se a porcentagem está entre 0 e 100
                if (descontoPercentual >= 0 && descontoPercentual <= 100)
                {
                    // Calcular o valor de desconto em reais
                    decimal valorDesconto = (descontoPercentual / 100) * TotalSemDesconto;

                    // Calcular o total com desconto
                    decimal TotalComDesconto = TotalSemDesconto - valorDesconto;

                    // Exibir o total com desconto
                    lblValorFinal.Text = $"R$ {TotalComDesconto:F2}";

                    // Exibir mensagem de confirmação
                    MessageBox.Show($"Desconto de {descontoPercentual:F2}% aplicado! Valor Descontado: R$ {valorDesconto:F2}");
                }
                else
                {
                    MessageBox.Show("Por favor, insira uma porcentagem de desconto entre 0 e 100.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor de desconto válido em porcentagem.");
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




















