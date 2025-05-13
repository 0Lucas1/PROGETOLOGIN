namespace ProjetoSGE
{
    partial class MenuCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCadastro));
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 0);
            button1.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(83, 69);
            button1.Name = "button1";
            button1.Size = new Size(619, 138);
            button1.TabIndex = 3;
            button1.Text = "USUÁRIO";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 128, 0);
            button2.DialogResult = DialogResult.Yes;
            button2.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(83, 258);
            button2.Name = "button2";
            button2.Size = new Size(619, 138);
            button2.TabIndex = 4;
            button2.Text = "ADMINISTRADOR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // MenuCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MenuCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Cadastro";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}