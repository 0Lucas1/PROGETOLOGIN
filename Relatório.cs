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

namespace PROGETOLOGIN
{
    public partial class Relatório : Form
    {

        public Relatório()
        {
            InitializeComponent();
            CarregarRelatorio();
            dataGridViewRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



        }
        public void exibirRelatorio()
        {
            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    string query = @"
                SELECT 
                    Usuarios.Usuario AS 'Usuário', 
                    Estoque.ID_Produto AS 'Produto', 
                    vendas.Quantidade AS 'Quantidade', 
                    vendas.Data_Venda AS 'Data da Venda', 
                    vendas.Valor_Total AS 'Faturamento', 
                    ((Estoque.Valor_Venda - Estoque.Valor_Compra) * vendas.Quantidade) AS 'Lucro'
                FROM 
                    vendas
                JOIN 
                    Estoque ON vendas.ID_Produto = Estoque.ID_Produto
                JOIN 
                    Usuarios ON vendas.ID_Usuario = Usuarios.Usuario
                WHERE 
                    DATE(vendas.Data_Venda) = CURDATE();";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Criando um DataTable para carregar os dados
                    DataTable tabela = new DataTable();
                    tabela.Load(reader);

                    // Definindo o DataTable como fonte de dados do DataGridView
                    dataGridViewRelatorio.DataSource = tabela;

                    // Ajusta largura automática das colunas
                    dataGridViewRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    MessageBox.Show("Relatório gerado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
        }


        private void CarregarRelatorio()
        {
            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    string query = @"
        SELECT 
            v.ID_Venda,
            e.Nome_Produto,
            v.Quantidade,
            v.Valor_Total,
            v.Data_Venda,
            u.Usuario AS Nome_Usuario
        FROM 
            vendas v
        JOIN 
            Estoque e ON v.ID_Produto = e.ID_Produto
        JOIN 
            Usuarios u ON Usuario = Usuario
        WHERE 
            DATE(v.Data_Venda) = CURDATE();";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Criando um DataTable para carregar os dados
                    DataTable tabela = new DataTable();
                    tabela.Load(reader);

                    // Definindo o DataTable como fonte de dados do DataGridView
                    dataGridViewRelatorio.DataSource = tabela;

                    // Ajusta largura automática das colunas
                    dataGridViewRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    MessageBox.Show("Relatório gerado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
        }

    }
}
