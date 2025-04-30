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
            TXTADM = new TextBox();
            TXTSENHA = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BTNAcessar = new Button();
            lblMensagem = new Label();
            lbltxt = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // TXTADM
            // 
            TXTADM.Location = new Point(251, 87);
            TXTADM.Name = "TXTADM";
            TXTADM.Size = new Size(175, 23);
            TXTADM.TabIndex = 0;
            // 
            // TXTSENHA
            // 
            TXTSENHA.Location = new Point(251, 151);
            TXTSENHA.Name = "TXTSENHA";
            TXTSENHA.Size = new Size(175, 23);
            TXTSENHA.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(184, 154);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "SENHA :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(128, 90);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 3;
            label2.Text = "ADMINISTRADOR : ";
            // 
            // BTNAcessar
            // 
            BTNAcessar.Location = new Point(272, 212);
            BTNAcessar.Name = "BTNAcessar";
            BTNAcessar.Size = new Size(128, 23);
            BTNAcessar.TabIndex = 4;
            BTNAcessar.Text = "ACESSAR";
            BTNAcessar.UseVisualStyleBackColor = true;
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
            // ADM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 284);
            Controls.Add(button1);
            Controls.Add(lbltxt);
            Controls.Add(lblMensagem);
            Controls.Add(BTNAcessar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TXTSENHA);
            Controls.Add(TXTADM);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ADM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ADM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TXTADM;
        private TextBox TXTSENHA;
        private Label label1;
        private Label label2;
        private Button BTNAcessar;
        private Label lblMensagem;
        private Label lbltxt;
        private Button button1;
    }
}