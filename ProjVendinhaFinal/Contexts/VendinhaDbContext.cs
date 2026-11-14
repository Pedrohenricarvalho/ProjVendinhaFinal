using System;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vendinha.Desktop.Contexts
{
    // Responsavel pela conexao e pela criacao das tabelas do banco.
    public class VendinhaDbContext
    {
        private static readonly string DbFile = "vendinha.db";
        private static readonly string ConnectionString = $"Data Source={DbFile}";

        public static SqliteConnection ObterConexao()
        {
            var conexao = new SqliteConnection(ConnectionString);
            conexao.Open();
            return conexao;
        }

        public static void InicializarBanco()
        {
            using (var conexao = ObterConexao())
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Clientes (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Cpf TEXT NOT NULL UNIQUE,
                        DataNascimento TEXT NOT NULL,
                        Email TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Dividas (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClienteId INTEGER NOT NULL,
                        Valor REAL NOT NULL,
                        EstaPaga INTEGER NOT NULL DEFAULT 0,
                        DataCriacao TEXT NOT NULL,
                        DataPagamento TEXT,
                        FOREIGN KEY (ClienteId) REFERENCES Clientes(Id) ON DELETE CASCADE
                    );";
                comando.ExecuteNonQuery();
            }
        }
    }
}
