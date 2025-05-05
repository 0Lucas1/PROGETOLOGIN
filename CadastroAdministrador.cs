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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
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
            using (var conexao = Conexao.Obterconexao())
            {
                string query = "INSERT INTO Admninstrador(USUARIO,senha) VALUES (@Usuario,@senha)";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@Usuario", email);
                cmd.Parameters.AddWithValue("@senha", senhaHash);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Administrador Cadastrado com sucesso");
                    this.Close();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Administrador já Cadastrado");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar Administrador" + ex.Message);
                    }
                }
            }

        }
    }
}

