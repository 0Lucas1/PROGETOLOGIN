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
            Grid_Relatorio = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Grid_Relatorio).BeginInit();
            SuspendLayout();
            // 
            // Grid_Relatorio
            // 
            Grid_Relatorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Relatorio.Location = new Point(3, 0);
            Grid_Relatorio.Name = "Grid_Relatorio";
            Grid_Relatorio.Size = new Size(884, 284);
            Grid_Relatorio.TabIndex = 0;
            Grid_Relatorio.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Relatório
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 285);
            Controls.Add(Grid_Relatorio);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Relatório";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Relatório";
            ((System.ComponentModel.ISupportInitialize)Grid_Relatorio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Grid_Relatorio;
    }
}