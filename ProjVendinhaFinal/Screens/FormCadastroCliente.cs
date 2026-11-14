using System;
using System.Windows.Forms;
using ProjVendinhaFinal.Models;
using ProjVendinhaFinal.Services;
using ProjVendinhaFinal.Utils;

namespace ProjVendinhaFinal.Screens
{
    public partial class FormCadastroCliente : Form
    {
        private readonly int? _clienteId;
        private readonly ClienteService _clienteService = new ClienteService();

        public FormCadastroCliente(int? clienteId = null)
        {
            InitializeComponent();
            _clienteId = clienteId;
            dtpDataNascimento.MaxDate = DateTime.Today;
            if (_clienteId.HasValue)
            {
                Text = "Editar Cliente";
                btnSalvar.Text = "Salvar Alterações";
                CarregarCliente();
            }
        }

        private void CarregarCliente()
        {
            var cliente = _clienteService.BuscarPorId(_clienteId.Value);
            if (cliente == null) return;
            txtNome.Text = cliente.Nome;
            txtCpf.Text = cliente.Cpf;
            txtEmail.Text = cliente.Email;
            dtpDataNascimento.Value = cliente.DataNascimento;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string cpf = Validacao.SomenteNumeros(txtCpf.Text);
            string email = txtEmail.Text.Trim();

            if (nome == "" || cpf == "") { MessageBox.Show("Preencha o nome e o CPF."); return; }
            if (!Validacao.ValidarCpf(cpf)) { MessageBox.Show("Digite um CPF válido."); return; }
            if (!Validacao.ValidarEmail(email)) { MessageBox.Show("Digite um e-mail válido ou deixe o campo vazio."); return; }
            if (dtpDataNascimento.Value.Date > DateTime.Today) { MessageBox.Show("A data de nascimento não pode ser futura."); return; }

            var cliente = new Cliente
            {
                Id = _clienteId ?? 0,
                Nome = nome,
                Cpf = cpf,
                Email = email,
                DataNascimento = dtpDataNascimento.Value.Date
            };

            if (!_clienteService.Salvar(cliente, out string mensagem))
            {
                MessageBox.Show(mensagem);
                return;
            }

            MessageBox.Show(_clienteId.HasValue ? "Cliente atualizado com sucesso!" : "Cliente cadastrado com sucesso!");
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
