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
    public partial class fORMSMENU : Form
    {
        public fORMSMENU()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formscaixa caixa = new formscaixa();
            caixa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Administrativo Administrativo = new Administrativo();
            Administrativo.Show();
            this.Hide();
        }
    }
}
