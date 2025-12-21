using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Extension
{
    public static class DepedenciaInjecaoExtension
    {

        private static void AddServicesApplication(IServiceCollection services)
        {


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




        }
    }
}
