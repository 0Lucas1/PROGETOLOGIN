namespace PROGETOLOGIN
{
    partial class LOGIN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TXTEMAIL = new TextBox();
            TXTSENHA = new TextBox();
            BTNACESSAR = new Button();
            BTNCADASTRAR = new Button();
            btnmostra = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // TXTEMAIL
            // 
            TXTEMAIL.Location = new Point(283, 129);
            TXTEMAIL.Name = "TXTEMAIL";
            TXTEMAIL.Size = new Size(211, 23);
            TXTEMAIL.TabIndex = 2;
            // 
            // TXTSENHA
            // 
            TXTSENHA.Location = new Point(283, 189);
            TXTSENHA.Name = "TXTSENHA";
            TXTSENHA.Size = new Size(211, 23);
            TXTSENHA.TabIndex = 3;
            // 
            // BTNACESSAR
            // 
            BTNACESSAR.BackColor = Color.FromArgb(255, 128, 0);
            BTNACESSAR.Cursor = Cursors.Hand;
            BTNACESSAR.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNACESSAR.Location = new Point(283, 249);
            BTNACESSAR.Name = "BTNACESSAR";
            BTNACESSAR.Size = new Size(209, 39);
            BTNACESSAR.TabIndex = 4;
            BTNACESSAR.Text = "ACESSAR";
            BTNACESSAR.UseVisualStyleBackColor = false;
            BTNACESSAR.Click += BTNACESSAR_Click;
            // 
            // BTNCADASTRAR
            // 
            BTNCADASTRAR.BackColor = Color.FromArgb(255, 128, 0);
            BTNCADASTRAR.Cursor = Cursors.Hand;
            BTNCADASTRAR.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTNCADASTRAR.Location = new Point(12, 399);
            BTNCADASTRAR.Name = "BTNCADASTRAR";
            BTNCADASTRAR.Size = new Size(326, 39);
            BTNCADASTRAR.TabIndex = 5;
            BTNCADASTRAR.Text = "CADASTRAR";
            BTNCADASTRAR.UseVisualStyleBackColor = false;
            BTNCADASTRAR.Click += BTNCADASTRAR_Click;
            // 
            // btnmostra
            // 
            btnmostra.Location = new Point(516, 189);
            btnmostra.Name = "btnmostra";
            btnmostra.Size = new Size(144, 23);
            btnmostra.TabIndex = 6;
            btnmostra.Text = "Mostrar Senha";
            btnmostra.UseVisualStyleBackColor = true;
            btnmostra.Click += btnmostra_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bernard MT Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(216, 193);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 7;
            label1.Text = "SENHA: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bernard MT Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(200, 129);
            label2.Name = "label2";
            label2.Size = new Size(77, 19);
            label2.TabIndex = 8;
            label2.Text = "USUÁRIO: ";
            // 
            // LOGIN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnmostra);
            Controls.Add(BTNCADASTRAR);
            Controls.Add(BTNACESSAR);
            Controls.Add(TXTSENHA);
            Controls.Add(TXTEMAIL);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LOGIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SGE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TXTEMAIL;
        private TextBox TXTSENHA;
        private Button BTNACESSAR;
        private Button BTNCADASTRAR;
        private Button btnmostra;
        private Label label1;
        private Label label2;
    }
}
