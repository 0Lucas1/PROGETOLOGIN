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
    public partial class FormsCadastrar : Form
    {
        public FormsCadastrar()
        {
            InitializeComponent();
            CarregarUsuarios(); // Chama a função para carregar os usuários na DataGridView
            ConfigdtUSUARIO();  // Configura a DataGridView
            dtUSUARIO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Encerramento);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string senha = txtSenha.Text;
            string confirmarSenha = txtCSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha Todos os Campos");
                return;
            }
            if (senha != confirmarSenha)
            {
                MessageBox.Show("As Senhas não Coincidem");
                return;
            }

            // Verifica se o e-mail já está cadastrado no banco de dados antes de inserir
            using (var conexao = Conexao.Obterconexao())
            {
                string query = "SELECT COUNT(*) FROM usuarios WHERE USUARIO = @Usuario";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@Usuario", email);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Usuario já cadastrado. Por favor, use outro Usuario.");
                    return;
                }
            }

            string senhaHash = Criptografia.GerarHash(senha);

            using (var conexao = Conexao.Obterconexao())
            {
                string query = "INSERT INTO usuarios(USUARIO, senha) VALUES (@Usuario, @senha)";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@Usuario", email);
                cmd.Parameters.AddWithValue("@senha", senhaHash);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário Cadastrado com sucesso");
                    CarregarUsuarios(); // Recarrega os usuários na DataGridView
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                }
            }
        }

        // Função para carregar os usuários na DataGridView
        private void CarregarUsuarios()
        {
            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    string query = "SELECT ID, USUARIO FROM usuarios"; // Seleciona apenas as colunas ID e USUARIO
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable tabela = new DataTable();
                    tabela.Load(reader);

                    // Preenche a DataGridView com os dados
                    dtUSUARIO.DataSource = tabela;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuários: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        // Função para configurar a DataGridView
        private void ConfigdtUSUARIO()
        {
            dtUSUARIO.ReadOnly = true;
            dtUSUARIO.AllowUserToAddRows = false;
            dtUSUARIO.AllowUserToDeleteRows = false;
            dtUSUARIO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtUSUARIO.MultiSelect = false;
        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            if (dtUSUARIO.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um usuário para deletar.");
                return;
            }

            // Verifica se só existe um usuário cadastrado
            if (dtUSUARIO.Rows.Count <= 1)
            {
                MessageBox.Show("Não é possível deletar o último usuário.");
                return;
            }

            // Pega o ID do usuário selecionado
            int idUsuario = Convert.ToInt32(dtUSUARIO.SelectedRows[0].Cells["ID"].Value);

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este usuário?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                using (var conexao = Conexao.Obterconexao())
                {
                    string query = "DELETE FROM usuarios WHERE ID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuário deletado com sucesso!");
                        CarregarUsuarios(); // Atualiza a lista de usuários
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao deletar usuário: " + ex.Message);
                    }
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
