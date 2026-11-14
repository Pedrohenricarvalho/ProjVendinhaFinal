using ProjVendinhaFinal.Contexts;
using ProjVendinhaFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjVendinhaFinal.Services
{
    public class ClienteService
    {
        public object Listar(string busca, int pagina, int itensPorPagina, out int totalClientes, out int totalPaginas)
        {
            var clientes = new List<dynamic>();
            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = @"
                    SELECT c.Id, c.Nome, c.Cpf, c.DataNascimento, c.Email,
                           COALESCE(SUM(CASE WHEN d.EstaPaga = 0 THEN d.Valor ELSE 0 END), 0) AS TotalDividas
                    FROM Clientes c
                    LEFT JOIN Dividas d ON d.ClienteId = c.Id
                    WHERE LOWER(c.Nome) LIKE LOWER($busca)
                    GROUP BY c.Id
                    ORDER BY TotalDividas DESC, c.Nome
                    LIMIT $limite OFFSET $offset;";
                comando.Parameters.AddWithValue("$busca", "%" + (busca ?? "") + "%");
                comando.Parameters.AddWithValue("$limite", itensPorPagina);
                comando.Parameters.AddWithValue("$offset", pagina * itensPorPagina);
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        DateTime nascimento = DateTime.Parse(leitor.GetString(3));
                        int idade = DateTime.Today.Year - nascimento.Year;
                        if (nascimento.Date > DateTime.Today.AddYears(-idade)) idade--;
                        clientes.Add(new
                        {
                            Id = leitor.GetInt32(0),
                            Nome = leitor.GetString(1),
                            Cpf = leitor.GetString(2),
                            Idade = idade,
                            Email = leitor.IsDBNull(4) ? "" : leitor.GetString(4),
                            TotalDividas = Convert.ToDecimal(leitor.GetValue(5))
                        });
                    }
                }
            }

            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT COUNT(*) FROM Clientes WHERE LOWER(Nome) LIKE LOWER($busca);";
                comando.Parameters.AddWithValue("$busca", "%" + (busca ?? "") + "%");
                totalClientes = Convert.ToInt32(comando.ExecuteScalar());
            }
            totalPaginas = Math.Max(1, (int)Math.Ceiling(totalClientes / (double)itensPorPagina));
            return clientes;
        }

        public Cliente? BuscarPorId(int id)
        {
            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT Id, Nome, Cpf, DataNascimento, Email FROM Clientes WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (!leitor.Read()) return null;
                    return new Cliente
                    {
                        Id = leitor.GetInt32(0),
                        Nome = leitor.GetString(1),
                        Cpf = leitor.GetString(2),
                        DataNascimento = DateTime.Parse(leitor.GetString(3)),
                        Email = leitor.IsDBNull(4) ? "" : leitor.GetString(4)
                    };
                }
            }
        }

        public bool Salvar(Cliente cliente, out string mensagem)
        {
            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT COUNT(*) FROM Clientes WHERE Cpf = $cpf AND Id <> $id;";
                comando.Parameters.AddWithValue("$cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("$id", cliente.Id);
                if (Convert.ToInt32(comando.ExecuteScalar()) > 0)
                {
                    mensagem = "Ja existe um cliente cadastrado com este CPF.";
                    return false;
                }

                comando.Parameters.Clear();
                if (cliente.Id == 0)
                    comando.CommandText = "INSERT INTO Clientes (Nome, Cpf, DataNascimento, Email) VALUES ($nome, $cpf, $nascimento, $email);";
                else
                {
                    comando.CommandText = "UPDATE Clientes SET Nome=$nome, Cpf=$cpf, DataNascimento=$nascimento, Email=$email WHERE Id=$id;";
                    comando.Parameters.AddWithValue("$id", cliente.Id);
                }
                comando.Parameters.AddWithValue("$nome", cliente.Nome);
                comando.Parameters.AddWithValue("$cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("$nascimento", cliente.DataNascimento.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("$email", cliente.Email ?? "");
                comando.ExecuteNonQuery();
                mensagem = "Cliente salvo com sucesso!";
                return true;
            }
        }

        public void Excluir(int id)
        {
            using (var conexao = VendinhaDbContext.ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "DELETE FROM Dividas WHERE ClienteId=$id; DELETE FROM Clientes WHERE Id=$id;";
                comando.Parameters.AddWithValue("$id", id);
                comando.ExecuteNonQuery();
            }
        }
    }
}
