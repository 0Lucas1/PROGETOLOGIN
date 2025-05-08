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
        }

        private void BTNCADASTRAR_Click(object sender, EventArgs e)
        {
            ADM adm = new ADM();
            adm.ShowDialog();
            this.Hide();
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
                    // Query que busca o usuário na tabela 'usuarios' com a senha correta
                    string query = "SELECT * FROM usuarios WHERE USUARIO = @USUARIO AND senha = @senha";
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
    }
}