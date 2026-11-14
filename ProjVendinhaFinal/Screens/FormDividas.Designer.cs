namespace ProjVendinhaFinal.Screens
{
    partial class FormDividas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnAdicionarDivida, btnPagarDivida;
        private System.Windows.Forms.DataGridView dgvDividas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblValor = new Label();
            txtValor = new TextBox();
            btnAdicionarDivida = new Button();
            btnPagarDivida = new Button();
            dgvDividas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDividas).BeginInit();
            SuspendLayout();
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(20, 22);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(111, 15);
            lblValor.TabIndex = 0;
            lblValor.Text = "Valor da dívida (R$):";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(145, 18);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(130, 23);
            txtValor.TabIndex = 1;
            // 
            // btnAdicionarDivida
            // 
            btnAdicionarDivida.BackColor = Color.SeaGreen;
            btnAdicionarDivida.Location = new Point(290, 16);
            btnAdicionarDivida.Name = "btnAdicionarDivida";
            btnAdicionarDivida.Size = new Size(145, 28);
            btnAdicionarDivida.TabIndex = 2;
            btnAdicionarDivida.Text = "Aplicar dívida";
            btnAdicionarDivida.UseVisualStyleBackColor = false;
            btnAdicionarDivida.Click += btnAdicionarDivida_Click;
            // 
            // btnPagarDivida
            // 
            btnPagarDivida.BackColor = Color.SeaGreen;
            btnPagarDivida.Location = new Point(450, 16);
            btnPagarDivida.Name = "btnPagarDivida";
            btnPagarDivida.Size = new Size(145, 28);
            btnPagarDivida.TabIndex = 3;
            btnPagarDivida.Text = "Marcar como paga";
            btnPagarDivida.UseVisualStyleBackColor = false;
            btnPagarDivida.Click += btnPagarDivida_Click;
            // 
            // dgvDividas
            // 
            dgvDividas.AllowUserToAddRows = false;
            dgvDividas.AllowUserToDeleteRows = false;
            dgvDividas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDividas.BackgroundColor = Color.FromArgb(192, 255, 192);
            dgvDividas.Location = new Point(20, 65);
            dgvDividas.MultiSelect = false;
            dgvDividas.Name = "dgvDividas";
            dgvDividas.ReadOnly = true;
            dgvDividas.RowHeadersVisible = false;
            dgvDividas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDividas.Size = new Size(575, 280);
            dgvDividas.TabIndex = 4;
            // 
            // FormDividas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(615, 365);
            Controls.Add(lblValor);
            Controls.Add(txtValor);
            Controls.Add(btnAdicionarDivida);
            Controls.Add(btnPagarDivida);
            Controls.Add(dgvDividas);
            Name = "FormDividas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gerenciamento de dívidas";
            ((System.ComponentModel.ISupportInitialize)dgvDividas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
