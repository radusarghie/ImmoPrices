using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Immo.Database.ConsoleUtil
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
           
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
