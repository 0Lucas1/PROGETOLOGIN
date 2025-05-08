namespace PROGETOLOGIN
{
    partial class Relatório
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
            dataGridViewRelatorio = new DataGridView();
            label1 = new Label();
            BTNsalvar = new Button();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRelatorio).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRelatorio
            // 
            dataGridViewRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRelatorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRelatorio.Location = new Point(3, 0);
            dataGridViewRelatorio.Name = "dataGridViewRelatorio";
            dataGridViewRelatorio.Size = new Size(884, 284);
            dataGridViewRelatorio.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 317);
            label1.Name = "label1";
            label1.Size = new Size(156, 25);
            label1.TabIndex = 1;
            label1.Text = "SALVAR EM PDF";
            // 
            // BTNsalvar
            // 
            BTNsalvar.Location = new Point(88, 360);
            BTNsalvar.Name = "BTNsalvar";
            BTNsalvar.Size = new Size(75, 23);
            BTNsalvar.TabIndex = 2;
            BTNsalvar.Text = "SALVAR";
            BTNsalvar.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(687, 290);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // Relatório
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 432);
            Controls.Add(dateTimePicker1);
            Controls.Add(BTNsalvar);
            Controls.Add(label1);
            Controls.Add(dataGridViewRelatorio);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Relatório";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Relatório";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRelatorio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewRelatorio;
        private Label label1;
        private Button BTNsalvar;
        private DateTimePicker dateTimePicker1;
    }
}