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
            txtemail = new TextBox();
            txtSenha = new TextBox();
            txtCSenha = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCadastrar = new Button();
            SuspendLayout();
            // 
            // txtemail
            // 
            txtemail.Location = new Point(289, 88);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(382, 23);
            txtemail.TabIndex = 0;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(289, 167);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(382, 23);
            txtSenha.TabIndex = 1;
            // 
            // txtCSenha
            // 
            txtCSenha.Location = new Point(289, 248);
            txtCSenha.Name = "txtCSenha";
            txtCSenha.PasswordChar = '*';
            txtCSenha.Size = new Size(382, 23);
            txtCSenha.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(211, 88);
            label1.Name = "label1";
            label1.Size = new Size(72, 19);
            label1.TabIndex = 3;
            label1.Text = "Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(202, 171);
            label2.Name = "label2";
            label2.Size = new Size(81, 19);
            label2.TabIndex = 4;
            label2.Text = "Senha : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(103, 252);
            label3.Name = "label3";
            label3.Size = new Size(180, 19);
            label3.TabIndex = 5;
            label3.Text = "Confirmar Senha :";
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.FromArgb(255, 128, 0);
            btnCadastrar.Cursor = Cursors.Hand;
            btnCadastrar.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = Color.Black;
            btnCadastrar.Location = new Point(352, 317);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(238, 36);
            btnCadastrar.TabIndex = 6;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // FormsCadastrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCadastrar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCSenha);
            Controls.Add(txtSenha);
            Controls.Add(txtemail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormsCadastrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SGE";
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
    }
}