using Npgsql;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interface;
using SistemaVendas.Domain.Models;
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
        public async Task<List<RelatorioVendaModel>> ObterRelatorioVendasAsync(
    DateTime dataInicio,
    DateTime dataFim)
        {
            var lista = new List<RelatorioVendaModel>();
            var inicio = dataInicio.Date;
            var fim = dataFim.Date.AddDays(1);


            const string sql = @"
        SELECT 
            v.data_venda,
            c.nome       AS cliente,
            p.nome       AS produto,
            i.quantidade,
            i.preco_venda
        FROM vendas v
        INNER JOIN clientes c    ON c.id = v.cliente_id
        INNER JOIN venda_itens i ON i.venda_id = v.id
        INNER JOIN produtos p    ON p.id = i.produto_id
        WHERE v.data_venda >= @inicio
  AND v.data_venda <  @fim
ORDER BY v.data_venda, c.nome
    ";

            await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);

            cmd.Parameters.AddWithValue("@inicio", inicio);
            cmd.Parameters.AddWithValue("@fim", fim);

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(new RelatorioVendaModel
                {
                    DataVenda = reader.GetDateTime(0),
                    Cliente = reader.GetString(1),
                    Produto = reader.GetString(2),
                    Quantidade = reader.GetInt32(3),
                    Preco = reader.GetDecimal(4)
                });
            }

            return lista;
        }

    }
}
