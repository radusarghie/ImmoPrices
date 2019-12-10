using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Immo.Database
{
    public class Startup
    {

        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

      

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ImmoContext>(cfg =>
            {
                cfg.UseSqlServer(config.GetConnectionString("ImmoConnectionString"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
