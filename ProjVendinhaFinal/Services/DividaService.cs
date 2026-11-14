using ProjVendinhaFinal.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjVendinhaFinal.Services
{
    public class DividaService
    {
        public string? NomeCliente(int clienteId)
        {
            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT Nome FROM Clientes WHERE Id=$id;";
                comando.Parameters.AddWithValue("$id", clienteId);
                return comando.ExecuteScalar()?.ToString();
            }
        }

        public object Listar(int clienteId)
        {
            var dividas = new List<object>();
            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = @"SELECT Id, Valor, EstaPaga, DataCriacao, DataPagamento
                    FROM Dividas WHERE ClienteId=$id ORDER BY DataCriacao DESC;";
                comando.Parameters.AddWithValue("$id", clienteId);
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                        dividas.Add(new
                        {
                            Id = leitor.GetInt32(0),
                            Valor = Convert.ToDecimal(leitor.GetValue(1)),
                            Situacao = leitor.GetInt32(2) == 1 ? "Paga" : "Em aberto",
                            DataCriacao = DateTime.Parse(leitor.GetString(3)),
                            DataPagamento = leitor.IsDBNull(4) ? (DateTime?)null : DateTime.Parse(leitor.GetString(4))
                        });
                }
            }
            return dividas;
        }

        public bool Adicionar(int clienteId, decimal valor, out string mensagem)
        {
            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT COUNT(*) FROM Dividas WHERE ClienteId=$id AND EstaPaga=0;";
                comando.Parameters.AddWithValue("$id", clienteId);
                if (Convert.ToInt32(comando.ExecuteScalar()) > 0)
                {
                    mensagem = "Este cliente ja possui uma divida em aberto. Marque-a como paga antes de cadastrar outra.";
                    return false;
                }
                comando.CommandText = "INSERT INTO Dividas (ClienteId, Valor, EstaPaga, DataCriacao) VALUES ($id, $valor, 0, $data);";
                comando.Parameters.AddWithValue("$valor", valor);
                comando.Parameters.AddWithValue("$data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                comando.ExecuteNonQuery();
                mensagem = "Divida cadastrada com sucesso!";
                return true;
            }
        }

        public bool MarcarComoPaga(int dividaId, out string mensagem)
        {
            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "UPDATE Dividas SET EstaPaga=1, DataPagamento=$data WHERE Id=$id AND EstaPaga=0;";
                comando.Parameters.AddWithValue("$data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                comando.Parameters.AddWithValue("$id", dividaId);
                if (comando.ExecuteNonQuery() == 0)
                {
                    mensagem = "Divida nao encontrada ou ja esta paga.";
                    return false;
                }
                mensagem = "Divida marcada como paga!";
                return true;
            }
        }
    }
}
