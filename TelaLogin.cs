using MySql.Data.MySqlClient;

namespace PROGETOLOGIN
{
    public partial class LOGIN : Form
    {

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
                string query = "SELECT  * FROM usuarios WHERE USUARIO =@USUARIO AND senha=@senha";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@USUARIO", usuario);
                cmd.Parameters.AddWithValue("@senha", senhahash);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Login Realizado com sucesso");
                    fORMSMENU menu = new fORMSMENU();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario ou Senha invalido");
                }
            }


            string adm = TXTEMAIL.Text;
            string senha2 = TXTSENHA.Text;
            string senhahash2 = Criptografia.GerarHash(senha2);
            using (var conexao = Conexao.Obterconexao())
            {
                string query = "SELECT  * FROM Admninstrador WHERE USUARIO =@USUARIO AND senha=@senha";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@USUARIO", adm);
                cmd.Parameters.AddWithValue("@senha", senhahash2);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Login Realizado com sucesso");
                    fORMSMENU menu = new fORMSMENU();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario ou Senha invalido");
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
