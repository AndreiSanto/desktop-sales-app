using Npgsql;
using SistemaVendas.Communication.Response;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interface;
using SistemaVendas.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Infrastructure.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IUnitOfWork _uow;

        public ClienteRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Cliente> CadastrarAsync(Cliente cliente)
        {
            const string sql = """
            INSERT INTO clientes (nome, email, telefone)
            VALUES (@nome, @email, @telefone)
            RETURNING id;
        """;

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
            cmd.Parameters.AddWithValue("nome", cliente.Nome);
            cmd.Parameters.AddWithValue("email", cliente.Email);
            cmd.Parameters.AddWithValue("telefone", cliente.Telefone);

            cliente.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return cliente;
        }
        public async Task<Cliente> AtualizarAsync(Cliente cliente)
        {
            const string sql = """
            UPDATE clientes
            SET nome = @nome,
                email = @email,
                telefone = @telefone
            WHERE id = @id;
        """;

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
            cmd.Parameters.AddWithValue("id", cliente.Id);
            cmd.Parameters.AddWithValue("nome", cliente.Nome);
            cmd.Parameters.AddWithValue("email", cliente.Email);
            cmd.Parameters.AddWithValue("telefone", cliente.Telefone);

            await cmd.ExecuteNonQueryAsync();
            return cliente;
        }
        public async Task<bool> ExcluirAsync(int id)
        {
            const string sql = """
            DELETE FROM clientes
            WHERE id = @id;
        """;

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
            cmd.Parameters.AddWithValue("id", id);

            var linhasAfetadas = await cmd.ExecuteNonQueryAsync();
            return linhasAfetadas > 0;
        }

        public async Task<Cliente> ObterClienteAsync(int id)
        {
            const string sql = """
            SELECT id, nome, email, telefone
            FROM clientes
            WHERE id = @id;
        """;

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
            cmd.Parameters.AddWithValue("id", id);

            await using var reader = await cmd.ExecuteReaderAsync();

            if (!reader.Read())
                return null;

            return new Cliente
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Email = reader.GetString(2),
                Telefone = reader.GetString(3)
            };
        }

        public async Task<List<Cliente>> ListarClientesAsync()
        {
            const string sql = """
        SELECT id, nome, email, telefone
        FROM clientes
        ORDER BY nome;
    """;

            var clientes = new List<Cliente>();

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                clientes.Add(new Cliente
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Telefone = reader.GetString(3)
                });
            }

            return clientes;
        }

        public async Task<bool> EmailJaExisteAsync(string email)
        {
            const string sql = """
        SELECT 1
        FROM clientes
        WHERE email = @email
        LIMIT 1;
    """;

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
            cmd.Parameters.AddWithValue("email", email);

            await using var reader = await cmd.ExecuteReaderAsync();

            return reader.Read();
        }

    }

}

