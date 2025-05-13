namespace PROGETOLOGIN
{
    partial class fORMSMENU
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
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 128, 0);
            button2.DialogResult = DialogResult.Yes;
            button2.Font = new Font("Bernard MT Condensed", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(408, 138);
            button2.Name = "button2";
            button2.Size = new Size(358, 138);
            button2.TabIndex = 1;
            button2.Text = "ESTOQUE";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 0);
            button1.Font = new Font("Bernard MT Condensed", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(28, 138);
            button1.Name = "button1";
            button1.Size = new Size(358, 138);
            button1.TabIndex = 2;
            button1.Text = "CAIXA";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // fORMSMENU
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(button2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "fORMSMENU";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SGE";
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Button button1;
    }
}