using Npgsql;
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
    public class VendaRepository : IVendaRepository
    {
        private readonly IUnitOfWork _uow;

        public VendaRepository(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<int> CriarVendaAsync(Venda venda)
        {
            const string sql = @"
            INSERT INTO vendas (cliente_id, data_venda)
            VALUES (@clienteId, @dataVenda)
            RETURNING id;
        ";

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
            cmd.Parameters.AddWithValue("@clienteId", venda.ClienteId);
            cmd.Parameters.AddWithValue("@dataVenda", venda.DataVenda);

            var vendaId = (int)await cmd.ExecuteScalarAsync();
            return vendaId;
        }

        public async Task CriarItemVendaAsync(VendaItem item)
        {
            const string sql = @"
            INSERT INTO venda_itens (venda_id, produto_id, quantidade, preco_venda)
            VALUES (@vendaId, @produtoId, @quantidade, @preco);
        ";

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
            cmd.Parameters.AddWithValue("@vendaId", item.VendaId);
            cmd.Parameters.AddWithValue("@produtoId", item.ProdutoId);
            cmd.Parameters.AddWithValue("@quantidade", item.Quantidade);
            cmd.Parameters.AddWithValue("@preco", item.PrecoVenda);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
