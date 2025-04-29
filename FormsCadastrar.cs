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
                MessageBox.Show("As Senhas não Coicidem");
                return;
            }
            string senhaHash = Criptografia.GerarHash(senha);
            using (var  conexao = Conexao.Obterconexao())
            {
                string query = "INSERT INTO usuarios(email,senha) VALUES (@email,@senha)";
                MySqlCommand cmd = new MySqlCommand(query,conexao);
                cmd.Parameters.AddWithValue("@email",email);
                cmd.Parameters.AddWithValue("@senha",senhaHash);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário Cadastrado com sucesso");
                    this.Close();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Email já Cadastrado");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar usuario" + ex.Message);
                    }
                }
            }

        }
    }
}
