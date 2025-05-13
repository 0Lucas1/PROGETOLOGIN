namespace PROGETOLOGIN
{
    partial class FormsCadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormsCadastrar));
            txtemail = new TextBox();
            txtSenha = new TextBox();
            txtCSenha = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCadastrar = new Button();
            label4 = new Label();
            button1 = new Button();
            dtUSUARIO = new DataGridView();
            BtnDeletar = new Button();
            ((System.ComponentModel.ISupportInitialize)dtUSUARIO).BeginInit();
            SuspendLayout();
            // 
            // txtemail
            // 
            txtemail.Location = new Point(247, 134);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(204, 23);
            txtemail.TabIndex = 0;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(247, 203);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(204, 23);
            txtSenha.TabIndex = 1;
            // 
            // txtCSenha
            // 
            txtCSenha.Location = new Point(251, 269);
            txtCSenha.Name = "txtCSenha";
            txtCSenha.PasswordChar = '*';
            txtCSenha.Size = new Size(204, 23);
            txtCSenha.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(174, 134);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 3;
            label1.Text = "Nome :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(160, 203);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 4;
            label2.Text = "Senha : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(65, 269);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 5;
            label3.Text = "Confirmar Senha :";
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.FromArgb(255, 128, 0);
            btnCadastrar.Cursor = Cursors.Hand;
            btnCadastrar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = Color.Black;
            btnCadastrar.Location = new Point(217, 344);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(238, 36);
            btnCadastrar.TabIndex = 6;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(368, 33);
            label4.Name = "label4";
            label4.Size = new Size(176, 21);
            label4.TabIndex = 7;
            label4.Text = "CADASTRO USUÁRIO";
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(731, 12);
            button1.Name = "button1";
            button1.Size = new Size(57, 25);
            button1.TabIndex = 8;
            button1.Text = "Voltar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtUSUARIO
            // 
            dtUSUARIO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtUSUARIO.Location = new Point(461, 134);
            dtUSUARIO.Name = "dtUSUARIO";
            dtUSUARIO.Size = new Size(327, 158);
            dtUSUARIO.TabIndex = 9;
            // 
            // BtnDeletar
            // 
            BtnDeletar.BackColor = Color.FromArgb(255, 128, 0);
            BtnDeletar.Cursor = Cursors.Hand;
            BtnDeletar.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnDeletar.ForeColor = Color.Black;
            BtnDeletar.Location = new Point(493, 345);
            BtnDeletar.Name = "BtnDeletar";
            BtnDeletar.Size = new Size(238, 36);
            BtnDeletar.TabIndex = 10;
            BtnDeletar.Text = "Deletar";
            BtnDeletar.UseVisualStyleBackColor = false;
            BtnDeletar.Click += BtnDeletar_Click;
            // 
            // FormsCadastrar
            // 
            AcceptButton = btnCadastrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnDeletar);
            Controls.Add(dtUSUARIO);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(btnCadastrar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCSenha);
            Controls.Add(txtSenha);
            Controls.Add(txtemail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormsCadastrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SGE";
            ((System.ComponentModel.ISupportInitialize)dtUSUARIO).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtemail;
        private TextBox txtSenha;
        private TextBox txtCSenha;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCadastrar;
        private Label label4;
        private Button button1;
        private DataGridView dtUSUARIO;
        private Button BtnDeletar;
    }
}