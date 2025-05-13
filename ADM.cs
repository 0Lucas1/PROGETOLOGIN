using MySql.Data.MySqlClient;
using ProjetoSGE;
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
    public partial class ADM : Form
    {
        private bool senhaVisivel = true;
        public ADM()
        {
            InitializeComponent();
            lbltxt.Text = "Acesso Administrativo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Encerramento);


        }

        private void BTNAcessar_Click(object sender, EventArgs e)
        {
            string usuario = TXTADM.Text;
            string senha = TXTSENHA.Text;
            string senhahash = Criptografia.GerarHash(senha);
            using (var conexao = Conexao.Obterconexao())
            {
                string query = "SELECT  * FROM Admninstrador WHERE USUARIO =@USUARIO AND senha=@senha";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@USUARIO", usuario);
                cmd.Parameters.AddWithValue("@senha", senhahash);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    LOGIN login = new LOGIN();
                    login.Close();
                    MessageBox.Show("Login Realizado com sucesso");
                    MenuCadastro menu = new MenuCadastro();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario ou Senha invalido");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        private void btnmostra_Click(object sender, EventArgs e)
        {
            if (senhaVisivel)
            {
                TXTSENHA.PasswordChar = '*';
                btnmostra.Text = "Mostrar";
                senhaVisivel = false;
            }
            else
            {
                TXTSENHA.PasswordChar = '\0';
                btnmostra.Text = "Esconder";
                senhaVisivel = true;
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
