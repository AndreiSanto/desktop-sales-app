using Microsoft.Extensions.DependencyInjection;
using SistemaVendas.Application.Service;
using SistemaVendas.Application.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Extension
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection services)
        {
            AddServicesApplication(services);

        }


        private static void AddServicesApplication(IServiceCollection services)
        {
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




        }
    }
}
