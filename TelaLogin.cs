using MySql.Data.MySqlClient;

namespace PROGETOLOGIN
{
    public partial class LOGIN : Form
    {
        // ✅ Variável estática que armazena o nome do usuário logado
        public static string UsuarioLogado;

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

            using (var conexao = Conexao.Obterconexao())
            {
                string query = "SELECT * FROM usuarios WHERE USUARIO = @USUARIO AND senha = @senha";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@USUARIO", usuario);
                cmd.Parameters.AddWithValue("@senha", senhahash);

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // ✅ Armazena o nome do usuário logado para uso global
                    UsuarioLogado = reader["USUARIO"].ToString();

                    MessageBox.Show("Login realizado com sucesso!");

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
    }
}
