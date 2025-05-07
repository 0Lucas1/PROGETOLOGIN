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
            dataGridViewRelatorio.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Relatório
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 285);
            Controls.Add(dataGridViewRelatorio);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Relatório";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Relatório";
            Load += Relatório_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRelatorio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewRelatorio;
    }
}