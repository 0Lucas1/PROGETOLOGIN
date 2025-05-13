using MySql.Data.MySqlClient;

namespace PROGETOLOGIN
{
    public partial class LOGIN : Form
    {

        // ✅ Variáveis estáticas para armazenar os dados do usuário logado
        public static string UsuarioLogado;
        public static int IDUsuarioLogado;

        private bool senhaVisivel;

        public LOGIN()
        {
            InitializeComponent();
            TXTSENHA.PasswordChar = '*';
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Encerramento);
        }



        private void BTNCADASTRAR_Click(object sender, EventArgs e)
        {
            ADM adm = new ADM(); // Passa o LOGIN para o ADM
            adm.ShowDialog();
            this.Hide();// Abre o ADM como modal, ou seja, bloqueia a interação com o LOGIN enquanto ADM estiver aberto
        }
        

        private void BTNACESSAR_Click(object sender, EventArgs e)
        {
            string usuario = TXTEMAIL.Text;
            string senha = TXTSENHA.Text;
            string senhahash = Criptografia.GerarHash(senha);

            // Verifica se o campo de e-mail ou senha está vazio
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            try
            {
                using (var conexao = Conexao.Obterconexao())
                {
                    // ⚠️ ALTERAÇÃO AQUI: adicionando COLLATE utf8mb4_bin para comparação case-sensitive
                    string query = "SELECT * FROM usuarios WHERE USUARIO COLLATE utf8mb4_bin = @USUARIO AND senha = @senha";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@USUARIO", usuario);
                    cmd.Parameters.AddWithValue("@senha", senhahash);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // ✅ Armazena o ID e o nome do usuário logado para uso global
                        IDUsuarioLogado = Convert.ToInt32(reader["ID"]);
                        UsuarioLogado = reader["USUARIO"].ToString();

                        MessageBox.Show("Login realizado com sucesso!");

                        // Exibe o menu após login bem-sucedido
                        fORMSMENU menu = new fORMSMENU();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválido.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
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
                btnmostra.Text = "Ocultar";
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

        private void btnaSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza de que deseja sair?",
                                          "Confirmar saída",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Encerra completamente a aplicação
            }
            // Se clicar em "Não", nada acontece — só fecha a caixa de diálogo
        }
    }
}
