using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVendas.Application;
using SistemaVendas.Application.Extension;
using SistemaVendas.Froms;
using SistemaVendas.Infrastructure.Data;
using SistemaVendas.Infrastructure.Extension;
using System;
using System.Windows.Forms;

namespace SistemaVendas.Forms
{
    public static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var services = new ServiceCollection();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

           
            services.AddSingleton(new DbConnectionFactory(connectionString));

            services.AddApplication();
            services.AddInfrastructure(configuration);
            services.AddScoped<TelaPrincipal>();
            services.AddTransient<frmClientes>();
            services.AddTransient<frmProdutos>();




            ServiceProvider = services.BuildServiceProvider();

            var formInicial = ServiceProvider
               .GetRequiredService<TelaPrincipal>();

            System.Windows.Forms.Application.Run(formInicial);

        }
    }
}
