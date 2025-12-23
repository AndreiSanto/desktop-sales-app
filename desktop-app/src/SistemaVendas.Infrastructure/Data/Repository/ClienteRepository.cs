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

        public Task<Cliente> AtualizarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
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

        public Task<bool> ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
