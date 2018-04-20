using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrighterDarkerMemory.Web.Data;
using BrighterDarkerMemory.Web.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Paramore.Darker.AspNetCore;

namespace BrighterDarkerMemory.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("SqlDatabaseConnection");
            services.AddDbContext<TestContext>(opts => opts.UseSqlServer(connectionString));

            services.AddDarker(opts =>
                {
                    opts.HandlerLifetime = ServiceLifetime.Scoped;
                })
                .AddHandlersFromAssemblies(typeof(TestQuery).Assembly);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
