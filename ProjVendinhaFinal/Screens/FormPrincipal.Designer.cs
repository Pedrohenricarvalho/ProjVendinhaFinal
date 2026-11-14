namespace ProjVendinhaFinal.Screens
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBuscar, btnNovoCliente, btnEditarCliente, btnExcluirCliente, btnGerenciarDividas, btnAnterior, btnProxima;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblTitulo, lblPagina;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            txtBusca = new TextBox();
            btnBuscar = new Button();
            btnNovoCliente = new Button();
            btnEditarCliente = new Button();
            btnExcluirCliente = new Button();
            btnGerenciarDividas = new Button();
            dgvClientes = new DataGridView();
            btnAnterior = new Button();
            btnProxima = new Button();
            lblPagina = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(18, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(309, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Vendinha | Clientes e dívidas";
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(22, 65);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Buscar cliente pelo nome";
            txtBusca.Size = new Size(260, 23);
            txtBusca.TabIndex = 1;
            txtBusca.KeyDown += txtBusca_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.SeaGreen;
            btnBuscar.Location = new Point(290, 63);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(85, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnNovoCliente
            // 
            btnNovoCliente.BackColor = Color.SeaGreen;
            btnNovoCliente.Location = new Point(390, 63);
            btnNovoCliente.Name = "btnNovoCliente";
            btnNovoCliente.Size = new Size(125, 27);
            btnNovoCliente.TabIndex = 3;
            btnNovoCliente.Text = "+ Novo cliente";
            btnNovoCliente.UseVisualStyleBackColor = false;
            btnNovoCliente.Click += btnNovoCliente_Click;
            // 
            // btnEditarCliente
            // 
            btnEditarCliente.BackColor = Color.SeaGreen;
            btnEditarCliente.Location = new Point(22, 465);
            btnEditarCliente.Name = "btnEditarCliente";
            btnEditarCliente.Size = new Size(115, 32);
            btnEditarCliente.TabIndex = 5;
            btnEditarCliente.Text = "Editar cliente";
            btnEditarCliente.UseVisualStyleBackColor = false;
            btnEditarCliente.Click += btnEditarCliente_Click;
            // 
            // btnExcluirCliente
            // 
            btnExcluirCliente.BackColor = Color.SeaGreen;
            btnExcluirCliente.Location = new Point(145, 465);
            btnExcluirCliente.Name = "btnExcluirCliente";
            btnExcluirCliente.Size = new Size(115, 32);
            btnExcluirCliente.TabIndex = 6;
            btnExcluirCliente.Text = "Excluir cliente";
            btnExcluirCliente.UseVisualStyleBackColor = false;
            btnExcluirCliente.Click += btnExcluirCliente_Click;
            // 
            // btnGerenciarDividas
            // 
            btnGerenciarDividas.BackColor = Color.SeaGreen;
            btnGerenciarDividas.Location = new Point(268, 465);
            btnGerenciarDividas.Name = "btnGerenciarDividas";
            btnGerenciarDividas.Size = new Size(145, 32);
            btnGerenciarDividas.TabIndex = 7;
            btnGerenciarDividas.Text = "Gerenciar dívidas";
            btnGerenciarDividas.UseVisualStyleBackColor = false;
            btnGerenciarDividas.Click += btnGerenciarDividas_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.FromArgb(192, 255, 192);
            dgvClientes.Location = new Point(22, 108);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(850, 340);
            dgvClientes.TabIndex = 4;
            // 
            // btnAnterior
            // 
            btnAnterior.BackColor = Color.SeaGreen;
            btnAnterior.Location = new Point(600, 465);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(85, 32);
            btnAnterior.TabIndex = 8;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnProxima
            // 
            btnProxima.BackColor = Color.SeaGreen;
            btnProxima.Location = new Point(785, 465);
            btnProxima.Name = "btnProxima";
            btnProxima.Size = new Size(85, 32);
            btnProxima.TabIndex = 10;
            btnProxima.Text = "Próxima";
            btnProxima.UseVisualStyleBackColor = false;
            btnProxima.Click += btnProxima_Click;
            // 
            // lblPagina
            // 
            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(690, 474);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(77, 15);
            lblPagina.TabIndex = 9;
            lblPagina.Text = "Página 1 de 1";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(895, 520);
            Controls.Add(lblTitulo);
            Controls.Add(txtBusca);
            Controls.Add(btnBuscar);
            Controls.Add(btnNovoCliente);
            Controls.Add(dgvClientes);
            Controls.Add(btnEditarCliente);
            Controls.Add(btnExcluirCliente);
            Controls.Add(btnGerenciarDividas);
            Controls.Add(btnAnterior);
            Controls.Add(lblPagina);
            Controls.Add(btnProxima);
            MinimumSize = new Size(911, 559);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vendinha";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
