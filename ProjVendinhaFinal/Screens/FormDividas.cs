using System;
using System.Globalization;
using System.Windows.Forms;
using ProjVendinhaFinal.Services;

namespace ProjVendinhaFinal.Screens
{
    public partial class FormDividas : Form
    {
        private readonly int _clienteId;
        private readonly DividaService _dividaService = new DividaService();

        public FormDividas(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
            string? nome = _dividaService.NomeCliente(_clienteId);
            if (nome != null) Text = "Dívidas de " + nome;
            CarregarDividas();
        }

        private void CarregarDividas()
        {
            dgvDividas.DataSource = _dividaService.Listar(_clienteId);
        }

        private void btnAdicionarDivida_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtValor.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal valor) || valor <= 0)
            {
                MessageBox.Show("Informe um valor válido maior que zero.");
                return;
            }

            if (!_dividaService.Adicionar(_clienteId, valor, out string mensagem))
            {
                MessageBox.Show(mensagem);
                return;
            }

            txtValor.Clear();
            CarregarDividas();
            MessageBox.Show(mensagem);
        }

        private void btnPagarDivida_Click(object sender, EventArgs e)
        {
            if (dgvDividas.SelectedRows.Count == 0) { MessageBox.Show("Selecione uma dívida."); return; }
            int id = Convert.ToInt32(dgvDividas.SelectedRows[0].Cells["Id"].Value);
            bool sucesso = _dividaService.MarcarComoPaga(id, out string mensagem);
            MessageBox.Show(mensagem);
            if (sucesso) CarregarDividas();
        }
    }
}
