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
            exibirRelatorio();
         

        }
        public void exibirRelatorio()
        {
            string dataHoje = DateTime.Today.ToString("yyyy-MM-dd");

            string sql = @"SELECT 
                        Nome_Usuario AS 'Usuário',
                        Nome_Produto AS 'Produto',
                        Quantidade AS 'Quantidade Vendida',
                        Data_Venda AS 'Data',
                        (Quantidade * Valor_Venda) AS 'Faturamento',
                        (Quantidade * (Valor_Venda - Valor_Compra)) AS 'Lucro'
                   FROM relatorio_vendas
                   WHERE Data_Venda = @data";

            using (var conn = Conexao.Obterconexao())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@data", dataHoje);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewRelatorio.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Relatório_Load(object sender, EventArgs e)
        {

        }
    }
}
