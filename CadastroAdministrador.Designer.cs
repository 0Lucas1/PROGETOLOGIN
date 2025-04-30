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
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtCSenha = new TextBox();
            txtSenha = new TextBox();
            txtemail = new TextBox();
            btnCadastrar = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(308, 76);
            label4.Name = "label4";
            label4.Size = new Size(232, 21);
            label4.TabIndex = 8;
            label4.Text = "CADASTRO ADMINISTRADOR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(168, 137);
            label1.Name = "label1";
            label1.Size = new Size(72, 19);
            label1.TabIndex = 9;
            label1.Text = "Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(159, 216);
            label2.Name = "label2";
            label2.Size = new Size(81, 19);
            label2.TabIndex = 10;
            label2.Text = "Senha : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(60, 297);
            label3.Name = "label3";
            label3.Size = new Size(180, 19);
            label3.TabIndex = 11;
            label3.Text = "Confirmar Senha :";
            // 
            // txtCSenha
            // 
            txtCSenha.Location = new Point(246, 297);
            txtCSenha.Name = "txtCSenha";
            txtCSenha.PasswordChar = '*';
            txtCSenha.Size = new Size(382, 23);
            txtCSenha.TabIndex = 14;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(246, 216);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(382, 23);
            txtSenha.TabIndex = 13;
            // 
            // txtemail
            // 
            txtemail.Location = new Point(246, 137);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(382, 23);
            txtemail.TabIndex = 12;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.FromArgb(255, 128, 0);
            btnCadastrar.Cursor = Cursors.Hand;
            btnCadastrar.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = Color.Black;
            btnCadastrar.Location = new Point(302, 356);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(238, 36);
            btnCadastrar.TabIndex = 15;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            // 
            // CadastroAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCadastrar);
            Controls.Add(txtCSenha);
            Controls.Add(txtSenha);
            Controls.Add(txtemail);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Name = "CadastroAdministrador";
            Text = "CadastroAdministrador";
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
    }
}