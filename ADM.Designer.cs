namespace PROGETOLOGIN
{
    partial class ADM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM));
            TXTADM = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BTNAcessar = new Button();
            lblMensagem = new Label();
            lbltxt = new Label();
            button1 = new Button();
            TXTSENHA = new TextBox();
            btnmostra = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // TXTADM
            // 
            TXTADM.Location = new Point(220, 90);
            TXTADM.Name = "TXTADM";
            TXTADM.Size = new Size(190, 23);
            TXTADM.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(162, 154);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "SENHA :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(97, 90);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 3;
            label2.Text = "ADMINISTRADOR : ";
            // 
            // BTNAcessar
            // 
            BTNAcessar.BackColor = Color.FromArgb(255, 128, 0);
            BTNAcessar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BTNAcessar.Location = new Point(238, 205);
            BTNAcessar.Name = "BTNAcessar";
            BTNAcessar.Size = new Size(128, 23);
            BTNAcessar.TabIndex = 4;
            BTNAcessar.Text = "ACESSAR";
            BTNAcessar.UseVisualStyleBackColor = false;
            BTNAcessar.Click += BTNAcessar_Click;
            // 
            // lblMensagem
            // 
            lblMensagem.AutoSize = true;
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Location = new Point(259, 187);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(0, 15);
            lblMensagem.TabIndex = 5;
            // 
            // lbltxt
            // 
            lbltxt.AutoSize = true;
            lbltxt.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltxt.Location = new Point(251, 47);
            lbltxt.Name = "lbltxt";
            lbltxt.Size = new Size(14, 21);
            lbltxt.TabIndex = 6;
            lbltxt.Text = ".";
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(557, 12);
            button1.Name = "button1";
            button1.Size = new Size(57, 25);
            button1.TabIndex = 7;
            button1.Text = "Voltar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TXTSENHA
            // 
            TXTSENHA.Location = new Point(220, 151);
            TXTSENHA.Name = "TXTSENHA";
            TXTSENHA.Size = new Size(190, 23);
            TXTSENHA.TabIndex = 1;
            // 
            // btnmostra
            // 
            btnmostra.BackColor = Color.FromArgb(255, 128, 0);
            btnmostra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnmostra.Location = new Point(422, 154);
            btnmostra.Name = "btnmostra";
            btnmostra.Size = new Size(96, 23);
            btnmostra.TabIndex = 8;
            btnmostra.Text = "Mostrar Senha";
            btnmostra.UseVisualStyleBackColor = false;
            btnmostra.Click += btnmostra_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(220, 27);
            label3.Name = "label3";
            label3.Size = new Size(190, 20);
            label3.TabIndex = 9;
            label3.Text = "ACESSO ADMINISTRATIVO";
            // 
            // ADM
            // 
            AcceptButton = BTNAcessar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(626, 284);
            Controls.Add(label3);
            Controls.Add(btnmostra);
            Controls.Add(button1);
            Controls.Add(lbltxt);
            Controls.Add(lblMensagem);
            Controls.Add(BTNAcessar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TXTSENHA);
            Controls.Add(TXTADM);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ADM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SGE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TXTADM;
        private Label label1;
        private Label label2;
        private Button BTNAcessar;
        private Label lblMensagem;
        private Label lbltxt;
        private Button button1;
        private TextBox TXTSENHA;
        private Button btnmostra;
        private Label label3;
    }
}