namespace ProjetoSGE
{
    partial class Administrativo
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            TXTADM = new TextBox();
            textBox1 = new TextBox();
            BTNAcessar = new Button();
            button1 = new Button();
            btnmostra = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(228, 37);
            label3.Name = "label3";
            label3.Size = new Size(190, 20);
            label3.TabIndex = 10;
            label3.Text = "ACESSO ADMINISTRATIVO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(105, 111);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 11;
            label2.Text = "ADMINISTRADOR : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(170, 160);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 12;
            label1.Text = "SENHA :";
            // 
            // TXTADM
            // 
            TXTADM.Location = new Point(228, 108);
            TXTADM.Name = "TXTADM";
            TXTADM.Size = new Size(175, 23);
            TXTADM.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(228, 157);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 23);
            textBox1.TabIndex = 14;
            // 
            // BTNAcessar
            // 
            BTNAcessar.BackColor = Color.FromArgb(255, 128, 0);
            BTNAcessar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BTNAcessar.Location = new Point(249, 217);
            BTNAcessar.Name = "BTNAcessar";
            BTNAcessar.Size = new Size(128, 23);
            BTNAcessar.TabIndex = 15;
            BTNAcessar.Text = "ACESSAR";
            BTNAcessar.UseVisualStyleBackColor = false;
            BTNAcessar.Click += BTNAcessar_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(557, 12);
            button1.Name = "button1";
            button1.Size = new Size(57, 25);
            button1.TabIndex = 16;
            button1.Text = "Voltar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnmostra
            // 
            btnmostra.BackColor = Color.FromArgb(255, 128, 0);
            btnmostra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnmostra.Location = new Point(425, 157);
            btnmostra.Name = "btnmostra";
            btnmostra.Size = new Size(96, 23);
            btnmostra.TabIndex = 17;
            btnmostra.Text = "Mostrar Senha";
            btnmostra.UseVisualStyleBackColor = false;
            btnmostra.Click += btnmostra_Click;
            // 
            // Administrativo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(626, 284);
            Controls.Add(btnmostra);
            Controls.Add(button1);
            Controls.Add(BTNAcessar);
            Controls.Add(textBox1);
            Controls.Add(TXTADM);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Administrativo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ADMINISTRATIVO";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox TXTADM;
        private TextBox textBox1;
        private Button BTNAcessar;
        private Button button1;
        private Button btnmostra;
    }
}