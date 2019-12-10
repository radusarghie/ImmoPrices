using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Immo.Database.ConsoleUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeConfiguration();

        }

        private static void InitializeConfiguration()
        {

            IServiceCollection services = new ServiceCollection();
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("config.json", false, true);
            IConfiguration configuration = configurationBuilder.Build();

            Startup startup = new Startup(configuration);
            startup.ConfigureServices(services);

        }

    }
}
