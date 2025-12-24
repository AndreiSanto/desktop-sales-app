using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVendas.Domain.Interface;
using SistemaVendas.Domain.Repository.Interface;
using SistemaVendas.Infrastructure.Data;
using SistemaVendas.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Infrastructure.Extension
{
    public static class DepedenciaInjecaoExtension
    {


        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
       
            AddApiContext(services, configuration);
            AddRepositories(services);

        }

        private static void AddApiContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApiContext>(options =>
                options.UseNpgsql(
                    connectionString
           
                )
            );

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();


        }
    }
}
