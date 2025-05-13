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
            this.Load += Relatório_Load;

            // Inicializa datas padrão
            dtInicio.Value = DateTime.Today;
            dtFIM.Value = DateTime.Today;

            // Evento do botão Filtrar
            btnFiltrar.Click += btnFiltrar_Click;

            // Aqui está a linha que expande a tabela!
            dataGridViewRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Relatório_Load(object sender, EventArgs e)
        {
            DeletarVendasAntigas();
            DateTime hoje = DateTime.Today;
            CarregarRelatorio(hoje, hoje);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = dtInicio.Value.Date;
            DateTime dataFim = dtFIM.Value.Date;

            if (dataInicio > dataFim)
            {
                MessageBox.Show("A data inicial não pode ser maior que a data final.");
                return;
            }

            CarregarRelatorio(dataInicio, dataFim);
        }

        private void CarregarRelatorio(DateTime dataInicio, DateTime dataFim)
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
                            Usuarios u ON v.ID_Usuario = u.ID
                        WHERE 
                            DATE(v.Data_Venda) BETWEEN @inicio AND @fim;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@inicio", dataInicio.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fim", dataFim.ToString("yyyy-MM-dd"));

                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable tabela = new DataTable();
                    tabela.Load(reader);

                    dataGridViewRelatorio.DataSource = tabela;
                }

                MessageBox.Show("Relatório filtrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
        }
        private void DeletarVendasAntigas()
        {
            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    string query = @"
                DELETE FROM vendas 
                WHERE Data_Venda < DATE_SUB(CURDATE(), INTERVAL 2 YEAR);";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show($"{linhasAfetadas} venda(s) com mais de 2 anos foram removidas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar vendas antigas: " + ex.Message);
            }
        }

        private void BTNsalvar_Click(object sender, EventArgs e)
        {
            // Criar um diálogo para escolher onde salvar o arquivo PDF
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF Files|*.pdf";
            saveFile.Title = "Salvar Relatório como PDF";
            saveFile.FileName = "relatorio_vendas.pdf";

            if (saveFile.ShowDialog() != DialogResult.OK)
                return;

            // Criação do documento PDF
            using (FileStream fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20f, 20f, 20f, 20f);
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Título do relatório
                var titulo = new iTextSharp.text.Paragraph("Relatório de Vendas", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD));
                titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                titulo.SpacingAfter = 20f;
                doc.Add(titulo);

                // Tabela com as colunas do relatório
                iTextSharp.text.pdf.PdfPTable tabela = new iTextSharp.text.pdf.PdfPTable(6);
                tabela.WidthPercentage = 100;
                tabela.SetWidths(new float[] { 10f, 25f, 15f, 20f, 20f, 10f }); // Ajuste das larguras

                // Cabeçalho da tabela
                tabela.AddCell("ID Venda");
                tabela.AddCell("Produto");
                tabela.AddCell("Quantidade");
                tabela.AddCell("Valor Total");
                tabela.AddCell("Data Venda");
                tabela.AddCell("Usuário");

                // Preencher a tabela com os dados do DataGridView
                foreach (DataGridViewRow row in dataGridViewRelatorio.Rows)
                {
                    if (row.IsNewRow) continue; // Ignorar a linha em branco no final

                    tabela.AddCell(row.Cells["ID_Venda"].Value.ToString());
                    tabela.AddCell(row.Cells["Nome_Produto"].Value.ToString());
                    tabela.AddCell(row.Cells["Quantidade"].Value.ToString());
                    tabela.AddCell(row.Cells["Valor_Total"].Value.ToString());
                    tabela.AddCell(row.Cells["Data_Venda"].Value.ToString());
                    tabela.AddCell(row.Cells["Nome_Usuario"].Value.ToString());
                }

                // Adicionar a tabela no documento PDF
                doc.Add(tabela);

                // Fechar o documento PDF
                doc.Close();
            }

            MessageBox.Show("Relatório exportado com sucesso!");
        }
    }
}

