using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Immo.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            var configuration = InitializeConfiguration(services);

            ImmoContextFactory ctxFactory = new ImmoContextFactory();

            ImmoSeeder seeder = new ImmoSeeder(new ImmoContext(configuration.GetConnectionString("ImmoConnectionString")));
            seeder.Seed();

        }

        private static IConfiguration InitializeConfiguration(IServiceCollection services)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("config.json", false, true);
            IConfiguration configuration = configurationBuilder.Build();
            
            Startup startup = new Startup(configuration);
            startup.ConfigureServices(services);

            return configuration;
        }

    }
}
