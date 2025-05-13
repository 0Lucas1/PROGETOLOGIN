namespace ProjetoSGE
{
    partial class CadastroAdministrador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroAdministrador));
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtCSenha = new TextBox();
            txtSenha = new TextBox();
            txtemail = new TextBox();
            btnCadastrar = new Button();
            button1 = new Button();
            dtAdm = new DataGridView();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dtAdm).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(328, 55);
            label4.Name = "label4";
            label4.Size = new Size(231, 21);
            label4.TabIndex = 8;
            label4.Text = "CADASTRO ADMINISTRADOR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(168, 137);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 9;
            label1.Text = "Nome :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(159, 216);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 10;
            label2.Text = "Senha : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(60, 297);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 11;
            label3.Text = "Confirmar Senha :";
            // 
            // txtCSenha
            // 
            txtCSenha.Location = new Point(246, 297);
            txtCSenha.Name = "txtCSenha";
            txtCSenha.PasswordChar = '*';
            txtCSenha.Size = new Size(176, 23);
            txtCSenha.TabIndex = 14;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(246, 216);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(176, 23);
            txtSenha.TabIndex = 13;
            // 
            // txtemail
            // 
            txtemail.Location = new Point(246, 137);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(176, 23);
            txtemail.TabIndex = 12;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.FromArgb(255, 128, 0);
            btnCadastrar.Cursor = Cursors.Hand;
            btnCadastrar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = Color.Black;
            btnCadastrar.Location = new Point(215, 377);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(238, 36);
            btnCadastrar.TabIndex = 15;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(731, 12);
            button1.Name = "button1";
            button1.Size = new Size(57, 25);
            button1.TabIndex = 16;
            button1.Text = "Voltar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtAdm
            // 
            dtAdm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtAdm.Location = new Point(452, 137);
            dtAdm.Name = "dtAdm";
            dtAdm.Size = new Size(336, 179);
            dtAdm.TabIndex = 17;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 128, 0);
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(548, 348);
            button2.Name = "button2";
            button2.Size = new Size(156, 30);
            button2.TabIndex = 18;
            button2.Text = "DELETAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // CadastroAdministrador
            // 
            AcceptButton = btnCadastrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(dtAdm);
            Controls.Add(button1);
            Controls.Add(btnCadastrar);
            Controls.Add(txtCSenha);
            Controls.Add(txtSenha);
            Controls.Add(txtemail);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "CadastroAdministrador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SGE";
            ((System.ComponentModel.ISupportInitialize)dtAdm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtCSenha;
        private TextBox txtSenha;
        private TextBox txtemail;
        private Button btnCadastrar;
        private Button button1;
        private DataGridView dtAdm;
        private Button button2;
    }
}