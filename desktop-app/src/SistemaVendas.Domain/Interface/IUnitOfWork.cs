using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Interface
{
    public interface IUnitOfWork
    {
        public Task BeginAsync();
        public Task CommitAsync();
        public Task RollbackAsync();
        NpgsqlConnection Connection { get; }
        NpgsqlTransaction Transaction { get; }
    }
}
