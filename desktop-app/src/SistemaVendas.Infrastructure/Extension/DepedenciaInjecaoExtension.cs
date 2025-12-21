using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVendas.Infrastructure.Data;
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
    }
}
