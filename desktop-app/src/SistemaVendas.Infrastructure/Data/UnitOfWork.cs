using Npgsql;
using SistemaVendas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        
            private readonly DbConnectionFactory _factory;
            private NpgsqlConnection _connection;
            private NpgsqlTransaction _transaction;

            public NpgsqlConnection Connection => _connection;
            public NpgsqlTransaction Transaction => _transaction;

            public UnitOfWork(DbConnectionFactory factory)
            {
                _factory = factory;
            }

            public async Task BeginAsync()
            {
                _connection = _factory.Create();
                await _connection.OpenAsync();
                _transaction = await _connection.BeginTransactionAsync();
            }

            public async Task CommitAsync()
                => await _transaction.CommitAsync();

            public async Task RollbackAsync()
                => await _transaction.RollbackAsync();

            public async Task DisposeAsync()
            {
                if (_transaction != null)
                    await _transaction.DisposeAsync();

                if (_connection != null)
                    await _connection.DisposeAsync();
            }
        }

    }
