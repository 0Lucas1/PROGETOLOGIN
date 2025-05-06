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
using static Produtos;

namespace PROGETOLOGIN
{
    public partial class formscaixa : Form
    {
        public formscaixa()
        {
            InitializeComponent();
            CarregarCategorias();
        }
        private void CarregarCategorias()
        {
            using (var conn = Conexao.Obterconexao())
            {
                string sql = "SELECT DISTINCT Categoria FROM Estoque";  // Pega as categorias únicas
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbtipo.Items.Add(reader.GetString("Categoria"));  // Adiciona as categorias na ComboBox
                }
            }
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProdutosDAO dao = new ProdutosDAO();
            if (cmbtipo.SelectedItem != null)
            {
                string categoriaSelecionada = cmbtipo.SelectedItem.ToString();
                List<Produto> produtos = dao.ListarPorCategoria(categoriaSelecionada);  // Chama o método para pegar os produtos da categoria

                cmbprodutos.DataSource = produtos;
                cmbprodutos.DisplayMember = "Nome_Produto";  // Exibe o nome do produto
                cmbprodutos.ValueMember = "ID_Produto";     // O valor associado é o ID do produto
            }
        }



        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            Relatório relatorio = new Relatório();
            relatorio.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }
    }
}
