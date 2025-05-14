using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

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

            // Expande a tabela automaticamente
            dataGridViewRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Relatório_Load(object sender, EventArgs e)
        {
            DeletarVendasAntigas();
            DateTime hoje = DateTime.Today;
            CarregarRelatorio(hoje, hoje.AddDays(1).AddSeconds(-1)); // Inclui o dia inteiro
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = dtInicio.Value.Date;  // Data sem hora (meia-noite)
            DateTime dataFim = dtFIM.Value.Date.AddDays(1).AddSeconds(-1);  // Final do dia (23:59:59)

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
                    // Ajusta as datas de início e fim para garantir que pegaremos o intervalo completo
                    string query = @"
        SELECT 
            v.ID_Venda,
            e.Nome_Produto,
            v.Quantidade,
            v.Valor_Total,
            v.Data_Venda,
            u.Usuario AS Nome_Usuario,
            e.Fornecedor  -- Adiciona o campo Fornecedor à consulta
        FROM 
            vendas v
        JOIN 
            Estoque e ON v.ID_Produto = e.ID_Produto
        JOIN 
            Usuarios u ON v.ID_Usuario = u.ID
        WHERE 
            v.Data_Venda >= @inicio 
            AND v.Data_Venda <= @fim
        ORDER BY 
            v.Data_Venda"; // Ordena para mostrar de forma cronológica

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Ajuste para garantir o formato correto de hora
                    cmd.Parameters.AddWithValue("@inicio", dataInicio.ToString("yyyy-MM-dd 00:00:00"));  // Define a hora para 00:00:00
                    cmd.Parameters.AddWithValue("@fim", dataFim.ToString("yyyy-MM-dd 23:59:59"));  // Define a hora para 23:59:59

                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable tabela = new DataTable();
                    tabela.Load(reader);

                    dataGridViewRelatorio.DataSource = tabela;
                }

                // Mensagem de sucesso após o relatório ser carregado
                MessageBox.Show("Relatório carregado com sucesso!");
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
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Salvar Relatório como PDF",
                FileName = "relatorio_vendas.pdf"
            };

            if (saveFile.ShowDialog() != DialogResult.OK)
                return;

            using (FileStream fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var titulo = new iTextSharp.text.Paragraph("Relatório de Vendas", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD))
                {
                    Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                doc.Add(titulo);

                PdfPTable tabela = new PdfPTable(6)
                {
                    WidthPercentage = 100
                };
                tabela.SetWidths(new float[] { 10f, 25f, 15f, 20f, 20f, 10f });

                // Cabeçalhos
                tabela.AddCell("ID Venda");
                tabela.AddCell("Produto");
                tabela.AddCell("Quantidade");
                tabela.AddCell("Valor Total");
                tabela.AddCell("Data Venda");
                tabela.AddCell("Usuário");

                foreach (DataGridViewRow row in dataGridViewRelatorio.Rows)
                {
                    if (row.IsNewRow) continue;

                    tabela.AddCell(row.Cells["ID_Venda"].Value?.ToString() ?? "");
                    tabela.AddCell(row.Cells["Nome_Produto"].Value?.ToString() ?? "");
                    tabela.AddCell(row.Cells["Quantidade"].Value?.ToString() ?? "");
                    tabela.AddCell(row.Cells["Valor_Total"].Value?.ToString() ?? "");
                    tabela.AddCell(row.Cells["Data_Venda"].Value?.ToString() ?? "");
                    tabela.AddCell(row.Cells["Nome_Usuario"].Value?.ToString() ?? "");
                }

                doc.Add(tabela);
                doc.Close();
            }

            MessageBox.Show("Relatório exportado com sucesso!");
        }
    }
}

