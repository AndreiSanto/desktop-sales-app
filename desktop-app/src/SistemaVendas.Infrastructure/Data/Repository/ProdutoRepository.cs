using Npgsql;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interface;
using SistemaVendas.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProdutoRepository : IProdutoRepository
{
    private readonly IUnitOfWork _uow;

    public ProdutoRepository(IUnitOfWork uow)
    {
        _uow = uow;
    }

    
    public async Task<Produto> CadastrarAsync(Produto produto)
    {
        const string sql = @"
            INSERT INTO produtos (nome, descricao, preco, quantidade_estoque)
            VALUES (@nome, @descricao, @preco, @estoque)
            RETURNING id;
        ";

        await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);

        cmd.Parameters.AddWithValue("nome", produto.Nome);
        cmd.Parameters.AddWithValue("descricao", produto.Descricao);
        cmd.Parameters.AddWithValue("preco", produto.Preco);
        cmd.Parameters.AddWithValue("estoque", produto.QtdEstoque);

        produto.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
        return produto;
    }

    public async Task<Produto> AtualizarAsync(Produto produto)
    {
        const string sql = @"
            UPDATE produtos
               SET nome = @nome,
                   descricao = @descricao,
                   preco = @preco,
                   quantidade_estoque = @estoque
             WHERE id = @id;
        ";

        await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);

        cmd.Parameters.AddWithValue("id", produto.Id);
        cmd.Parameters.AddWithValue("nome", produto.Nome);
        cmd.Parameters.AddWithValue("descricao", produto.Descricao);
        cmd.Parameters.AddWithValue("preco", produto.Preco);
        cmd.Parameters.AddWithValue("estoque", produto.QtdEstoque);

        await cmd.ExecuteNonQueryAsync();
        return produto;
    }


    public async Task<bool> ExcluirAsync(int id)
    {
        const string sql = "DELETE FROM produtos WHERE id = @id";

        await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
        cmd.Parameters.AddWithValue("id", id);

        return await cmd.ExecuteNonQueryAsync() > 0;
    }

 
    public async Task<List<Produto>> ListarProdutoAsync()
    {
        const string sql = @"
            SELECT id, nome, descricao, preco, quantidade_estoque
              FROM produtos
             ORDER BY nome;
        ";

        var produtos = new List<Produto>();

        await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
        await using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            produtos.Add(new Produto
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Descricao = reader.GetString(2),
                Preco = reader.GetDecimal(3),
                QtdEstoque = reader.GetInt32(4)
            });
        }

        return produtos;
    }


    public async Task<Produto?> ObterProdutoAsync(int id)
    {
        const string sql = @"
            SELECT id, nome, descricao, preco, quantidade_estoque
              FROM produtos
             WHERE id = @id;
        ";

        await using var cmd = new NpgsqlCommand(sql, _uow.Connection, _uow.Transaction);
        cmd.Parameters.AddWithValue("id", id);

        await using var reader = await cmd.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        return new Produto
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Descricao = reader.GetString(2),
            Preco = reader.GetDecimal(3),
            QtdEstoque = reader.GetInt32(4)
        };
    }
}
