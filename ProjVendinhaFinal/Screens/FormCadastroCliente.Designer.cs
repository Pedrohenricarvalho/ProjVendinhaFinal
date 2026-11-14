namespace ProjVendinhaFinal.Screens
{
    partial class FormCadastroCliente
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNome, lblCpf, lblEmail, lblDataNascimento;
        private System.Windows.Forms.TextBox txtNome, txtCpf, txtEmail;
        private System.Windows.Forms.DateTimePicker dtpDataNascimento;
        private System.Windows.Forms.Button btnSalvar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNome = new Label();
            txtNome = new TextBox();
            lblCpf = new Label();
            txtCpf = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDataNascimento = new Label();
            dtpDataNascimento = new DateTimePicker();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(24, 22);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(102, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome completo *";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(24, 45);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(330, 23);
            txtNome.TabIndex = 1;
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Location = new Point(24, 82);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(36, 15);
            lblCpf.TabIndex = 2;
            lblCpf.Text = "CPF *";
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(24, 105);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(330, 23);
            txtCpf.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(24, 202);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(98, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "E-mail (opcional)";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(24, 225);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblDataNascimento
            // 
            lblDataNascimento.AutoSize = true;
            lblDataNascimento.Location = new Point(24, 142);
            lblDataNascimento.Name = "lblDataNascimento";
            lblDataNascimento.Size = new Size(120, 15);
            lblDataNascimento.TabIndex = 4;
            lblDataNascimento.Text = "Data de nascimento *";
            // 
            // dtpDataNascimento
            // 
            dtpDataNascimento.Format = DateTimePickerFormat.Short;
            dtpDataNascimento.Location = new Point(24, 165);
            dtpDataNascimento.Name = "dtpDataNascimento";
            dtpDataNascimento.Size = new Size(330, 23);
            dtpDataNascimento.TabIndex = 5;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.SeaGreen;
            btnSalvar.Location = new Point(24, 270);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(330, 36);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar Cliente";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // FormCadastroCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(479, 422);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblCpf);
            Controls.Add(txtCpf);
            Controls.Add(lblDataNascimento);
            Controls.Add(dtpDataNascimento);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnSalvar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormCadastroCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Cliente";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
