namespace PROGETOLOGIN
{
    partial class formscaixa
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
            listCarrinho = new ListBox();
            numericUpDown1 = new NumericUpDown();
            cmbFormasDePagamento = new ComboBox();
            btnAdicionar = new Button();
            label2 = new Label();
            lblValorFinal = new Label();
            cmbprodutos = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblValorTotal = new Label();
            lblDesconto = new Label();
            btnRelatorio = new Button();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            label1 = new Label();
            label9 = new Label();
            BTNPAGAR = new Button();
            label10 = new Label();
            cmbtipo = new ComboBox();
            button2 = new Button();
            BtnBuscar = new Button();
            txtValorPagamento = new TextBox();
            label3 = new Label();
            lblTroco = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // listCarrinho
            // 
            listCarrinho.Font = new Font("Calibri", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            listCarrinho.FormattingEnabled = true;
            listCarrinho.ItemHeight = 26;
            listCarrinho.Location = new Point(25, 29);
            listCarrinho.Name = "listCarrinho";
            listCarrinho.Size = new Size(634, 264);
            listCarrinho.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(665, 202);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(211, 23);
            numericUpDown1.TabIndex = 1;
            // 
            // cmbFormasDePagamento
            // 
            cmbFormasDePagamento.FormattingEnabled = true;
            cmbFormasDePagamento.Location = new Point(375, 351);
            cmbFormasDePagamento.Name = "cmbFormasDePagamento";
            cmbFormasDePagamento.Size = new Size(200, 23);
            cmbFormasDePagamento.TabIndex = 2;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Cursor = Cursors.Hand;
            btnAdicionar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdicionar.Location = new Point(685, 252);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(159, 33);
            btnAdicionar.TabIndex = 3;
            btnAdicionar.Text = "ADICIONAR";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(255, 128, 0);
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 577);
            label2.Name = "label2";
            label2.Size = new Size(252, 40);
            label2.TabIndex = 5;
            label2.Text = "TOTAL A PAGAR: ";
            // 
            // lblValorFinal
            // 
            lblValorFinal.AutoSize = true;
            lblValorFinal.BackColor = Color.FromArgb(255, 128, 0);
            lblValorFinal.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorFinal.ForeColor = Color.White;
            lblValorFinal.Location = new Point(283, 577);
            lblValorFinal.Name = "lblValorFinal";
            lblValorFinal.Size = new Size(25, 40);
            lblValorFinal.TabIndex = 6;
            lblValorFinal.Text = " ";
            // 
            // cmbprodutos
            // 
            cmbprodutos.FormattingEnabled = true;
            cmbprodutos.Location = new Point(941, 105);
            cmbprodutos.Name = "cmbprodutos";
            cmbprodutos.Size = new Size(211, 23);
            cmbprodutos.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(25, 337);
            label4.Name = "label4";
            label4.Size = new Size(344, 37);
            label4.TabIndex = 8;
            label4.Text = "FORMA DE PAGAMENTO :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Black;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(25, 408);
            label5.Name = "label5";
            label5.Size = new Size(206, 37);
            label5.TabIndex = 9;
            label5.Text = "VALOR TOTAL :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Black;
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(25, 468);
            label6.Name = "label6";
            label6.Size = new Size(166, 37);
            label6.TabIndex = 10;
            label6.Text = "DESCONTO:";
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.BackColor = Color.Black;
            lblValorTotal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorTotal.ForeColor = SystemColors.Control;
            lblValorTotal.Location = new Point(237, 408);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(24, 37);
            lblValorTotal.TabIndex = 11;
            lblValorTotal.Text = ".";
            // 
            // lblDesconto
            // 
            lblDesconto.AutoSize = true;
            lblDesconto.BackColor = Color.Black;
            lblDesconto.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDesconto.ForeColor = SystemColors.ControlLightLight;
            lblDesconto.Location = new Point(184, 468);
            lblDesconto.Name = "lblDesconto";
            lblDesconto.Size = new Size(24, 37);
            lblDesconto.TabIndex = 12;
            lblDesconto.Text = ".";
            // 
            // btnRelatorio
            // 
            btnRelatorio.Cursor = Cursors.Hand;
            btnRelatorio.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRelatorio.Location = new Point(573, 578);
            btnRelatorio.Name = "btnRelatorio";
            btnRelatorio.Size = new Size(211, 39);
            btnRelatorio.TabIndex = 13;
            btnRelatorio.Text = "RELATÓRIO DE VENDAS";
            btnRelatorio.UseVisualStyleBackColor = true;
            btnRelatorio.Click += btnRelatorio_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(255, 128, 0);
            pictureBox5.Location = new Point(2, 1);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(1182, 645);
            pictureBox5.TabIndex = 18;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Black;
            pictureBox6.Location = new Point(12, 12);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(1159, 620);
            pictureBox6.TabIndex = 19;
            pictureBox6.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(941, 49);
            label1.Name = "label1";
            label1.Size = new Size(154, 37);
            label1.TabIndex = 20;
            label1.Text = "PRODUTO:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Black;
            label9.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(665, 141);
            label9.Name = "label9";
            label9.Size = new Size(201, 37);
            label9.TabIndex = 21;
            label9.Text = "QUANTIDADE:";
            // 
            // BTNPAGAR
            // 
            BTNPAGAR.BackColor = Color.FromArgb(255, 128, 0);
            BTNPAGAR.Cursor = Cursors.Hand;
            BTNPAGAR.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BTNPAGAR.Location = new Point(804, 539);
            BTNPAGAR.Name = "BTNPAGAR";
            BTNPAGAR.Size = new Size(226, 78);
            BTNPAGAR.TabIndex = 22;
            BTNPAGAR.Text = "PAGAR";
            BTNPAGAR.UseVisualStyleBackColor = false;
            BTNPAGAR.Click += BTNPAGAR_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Black;
            label10.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(665, 49);
            label10.Name = "label10";
            label10.Size = new Size(86, 37);
            label10.TabIndex = 23;
            label10.Text = "TIPO:";
            // 
            // cmbtipo
            // 
            cmbtipo.FormattingEnabled = true;
            cmbtipo.Location = new Point(665, 105);
            cmbtipo.Name = "cmbtipo";
            cmbtipo.Size = new Size(148, 23);
            cmbtipo.TabIndex = 24;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1059, 580);
            button2.Name = "button2";
            button2.Size = new Size(93, 33);
            button2.TabIndex = 25;
            button2.Text = "VOLTAR";
            button2.UseVisualStyleBackColor = true;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Cursor = Cursors.Hand;
            BtnBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnBuscar.Location = new Point(832, 99);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(93, 29);
            BtnBuscar.TabIndex = 26;
            BtnBuscar.Text = "BUSCAR";
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // txtValorPagamento
            // 
            txtValorPagamento.Location = new Point(602, 351);
            txtValorPagamento.Name = "txtValorPagamento";
            txtValorPagamento.Size = new Size(149, 23);
            txtValorPagamento.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(752, 337);
            label3.Name = "label3";
            label3.Size = new Size(122, 37);
            label3.TabIndex = 28;
            label3.Text = "TROCO: ";
            // 
            // lblTroco
            // 
            lblTroco.AutoSize = true;
            lblTroco.BackColor = Color.Black;
            lblTroco.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTroco.ForeColor = SystemColors.ControlLightLight;
            lblTroco.Location = new Point(867, 336);
            lblTroco.Name = "lblTroco";
            lblTroco.Size = new Size(24, 37);
            lblTroco.TabIndex = 29;
            lblTroco.Text = ".";
            // 
            // formscaixa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1183, 644);
            Controls.Add(lblTroco);
            Controls.Add(lblDesconto);
            Controls.Add(label3);
            Controls.Add(txtValorPagamento);
            Controls.Add(BtnBuscar);
            Controls.Add(button2);
            Controls.Add(cmbtipo);
            Controls.Add(label10);
            Controls.Add(BTNPAGAR);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(btnRelatorio);
            Controls.Add(lblValorTotal);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cmbprodutos);
            Controls.Add(lblValorFinal);
            Controls.Add(label2);
            Controls.Add(btnAdicionar);
            Controls.Add(cmbFormasDePagamento);
            Controls.Add(numericUpDown1);
            Controls.Add(listCarrinho);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            MaximizeBox = false;
            Name = "formscaixa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formscaixa";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listCarrinho;
        private NumericUpDown numericUpDown1;
        private ComboBox cmbFormasDePagamento;
        private Button button1;
        private Label label2;
        private Label lblValorFinal;
        private ComboBox cmbprodutos;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblValorTotal;
        private Label lblDesconto;
        private Button btnRelatorio;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Label label1;
        private Label label9;
        private Button BTNPAGAR;
        private Label label10;
        private ComboBox cmbtipo;
        private Button button2;
        private Button BtnBuscar;
        private Button btnAdicionar;
        private TextBox txtValorPagamento;
        private Label label3;
        private Label lblTroco;
        private DateTimePicker dateTimePicker1;
    }
}