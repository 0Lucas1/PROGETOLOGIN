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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatório));
            dataGridViewRelatorio = new DataGridView();
            label1 = new Label();
            BTNsalvar = new Button();
            dtFIM = new DateTimePicker();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            dtInicio = new DateTimePicker();
            btnFiltrar = new Button();
            label2 = new Label();
            label3 = new Label();
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
            BTNsalvar.Click += BTNsalvar_Click;
            // 
            // dtFIM
            // 
            dtFIM.Location = new Point(651, 352);
            dtFIM.Name = "dtFIM";
            dtFIM.Size = new Size(200, 23);
            dtFIM.TabIndex = 3;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // dtInicio
            // 
            dtInicio.Location = new Point(408, 352);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(200, 23);
            dtInicio.TabIndex = 4;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrar.Location = new Point(531, 411);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(179, 33);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "FILTRAR";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(712, 306);
            label2.Name = "label2";
            label2.Size = new Size(83, 21);
            label2.TabIndex = 6;
            label2.Text = "DATA FIM";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(461, 306);
            label3.Name = "label3";
            label3.Size = new Size(105, 21);
            label3.TabIndex = 7;
            label3.Text = "DATA INICIO";
            // 
            // Relatório
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 506);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnFiltrar);
            Controls.Add(dtInicio);
            Controls.Add(dtFIM);
            Controls.Add(BTNsalvar);
            Controls.Add(label1);
            Controls.Add(dataGridViewRelatorio);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private DateTimePicker dtFIM;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private DateTimePicker dtInicio;
        private Button btnFiltrar;
        private Label label2;
        private Label label3;
    }
}