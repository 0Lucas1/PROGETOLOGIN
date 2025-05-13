using MySql.Data.MySqlClient;
using PROGETOLOGIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSGE
{
    public partial class CadastroAdministrador : Form
    {
        public CadastroAdministrador()
        {
            InitializeComponent();
            CarregarAdministradores(); // Chama a função ao iniciar o formulário
            ConfigdtAdm();
            dtAdm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text.Trim();
            string senha = txtSenha.Text;
            string confirmarSenha = txtCSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            if (senha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem.");
                return;
            }

            string senhaHash = Criptografia.GerarHash(senha);

            using (var conexao = Conexao.Obterconexao())
            {
                // Verifica se o usuário já existe com case-sensitive
                string checkQuery = "SELECT COUNT(*) FROM Admninstrador WHERE BINARY USUARIO = @Usuario";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conexao);
                checkCmd.Parameters.AddWithValue("@Usuario", email);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Administrador já cadastrado com este usuário.");
                    return;
                }

                string insertQuery = "INSERT INTO Admninstrador(USUARIO, senha) VALUES (@Usuario, @senha)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conexao);
                cmd.Parameters.AddWithValue("@Usuario", email);
                cmd.Parameters.AddWithValue("@senha", senhaHash);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Administrador cadastrado com sucesso.");
                    CarregarAdministradores();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro ao cadastrar Administrador: " + ex.Message);
                }
            }
        }

        private void CarregarAdministradores()
        {
            try
            {
                using (var conn = Conexao.Obterconexao())
                {
                    string query = "SELECT ID_adm, USUARIO FROM Admninstrador";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable tabela = new DataTable();
                    tabela.Load(reader);

                    dtAdm.DataSource = tabela;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar administradores: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtAdm.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um administrador para deletar.");
                return;
            }

            // Verifica se só existe um administrador cadastrado
            if (dtAdm.Rows.Count <= 1)
            {
                MessageBox.Show("Não é possível deletar o último administrador.");
                return;
            }

            int idAdm = Convert.ToInt32(dtAdm.SelectedRows[0].Cells["ID_adm"].Value);

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este administrador?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                using (var conexao = Conexao.Obterconexao())
                {
                    string query = "DELETE FROM Admninstrador WHERE ID_adm = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@id", idAdm);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Administrador deletado com sucesso!");
                        CarregarAdministradores();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao deletar administrador: " + ex.Message);
                    }
                }
            }
        }

        private void ConfigdtAdm()
        {
            dtAdm.ReadOnly = true;
            dtAdm.AllowUserToAddRows = false;
            dtAdm.AllowUserToDeleteRows = false;
            dtAdm.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtAdm.MultiSelect = false;
        }
    }
}




