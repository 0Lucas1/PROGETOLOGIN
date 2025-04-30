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
        public ADM()
        {
            InitializeComponent();
            lbltxt.Text = "Acesso Administrativo";
        }

        private void BTNAcessar_Click(object sender, EventArgs e)
        {
            string adm = "Lucas";
            string Senha = "1234";
            if (TXTADM.Text == adm & TXTSENHA.Text == Senha)
            {

                MenuCadastro cadastro = new MenuCadastro();
                cadastro.Show();
                this.Hide();



            }
            else
            {
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Text = "Usuário ou senha incorretos";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }
    }
}
