using ProjVendinhaFinal.Services;
using System;
using System.Windows.Forms;

namespace ProjVendinhaFinal.Screens
{
    public partial class FormPrincipal : Form
    {
        private int _paginaAtual = 0;
        private const int ItensPorPagina = 10;
        private readonly ClienteService _clienteService = new ClienteService();

        public FormPrincipal()
        {
            InitializeComponent();
            CarregarClientes();
        }

        public void CarregarClientes()
        {
            int totalClientes, totalPaginas;
            dgvClientes.DataSource = _clienteService.Listar(txtBusca.Text.Trim(), _paginaAtual,
                ItensPorPagina, out totalClientes, out totalPaginas);

            _paginaAtual = Math.Max(0, Math.Min(_paginaAtual, totalPaginas - 1));
            lblPagina.Text = $"Página {_paginaAtual + 1} de {totalPaginas}  |  {totalClientes} cliente(s)";
            btnAnterior.Enabled = _paginaAtual > 0;
            btnProxima.Enabled = _paginaAtual < totalPaginas - 1;
        }

        private int? ClienteSelecionadoId()
        {
            if (dgvClientes.SelectedRows.Count == 0) return null;
            return Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value);
        }

        private void btnBuscar_Click(object sender, EventArgs e) { _paginaAtual = 0; CarregarClientes(); }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            using (var form = new FormCadastroCliente())
                if (form.ShowDialog() == DialogResult.OK) CarregarClientes();
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            int? id = ClienteSelecionadoId();
            if (!id.HasValue) { MessageBox.Show("Selecione um cliente."); return; }
            using (var form = new FormCadastroCliente(id.Value))
                if (form.ShowDialog() == DialogResult.OK) CarregarClientes();
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            int? id = ClienteSelecionadoId();
            if (!id.HasValue) { MessageBox.Show("Selecione um cliente."); return; }
            if (MessageBox.Show("Deseja excluir este cliente e todas as dívidas dele?", "Confirmar exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            _clienteService.Excluir(id.Value);
            CarregarClientes();
        }

        private void btnGerenciarDividas_Click(object sender, EventArgs e)
        {
            int? id = ClienteSelecionadoId();
            if (!id.HasValue) { MessageBox.Show("Selecione um cliente."); return; }
            using (var form = new FormDividas(id.Value)) form.ShowDialog();
            CarregarClientes();
        }

        private void btnAnterior_Click(object sender, EventArgs e) { _paginaAtual--; CarregarClientes(); }
        private void btnProxima_Click(object sender, EventArgs e) { _paginaAtual++; CarregarClientes(); }
        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { _paginaAtual = 0; CarregarClientes(); e.SuppressKeyPress = true; }
        }
    }
}
