using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage.Blob;
using AzureStorage.TableStorage;
using Concurrency.EFCORE;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureStorage.Sample
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
            services.AddControllers();
            services.AddScoped<ITodoRepo, BlobRepo>();
            services.AddScoped<ITableStorageRepo, TableStorageRepo>();
            services.AddTransient<IStudRepo, StudRepo>();

            //if UseSQL server doesnt show up then remove Microsoft.VisualStudio.Web.CodeGenerators
            services.AddDbContext<SampleDbContext>(options => options.UseSqlServer(@"Server=DESKTOP-7RUDNLS\SQLEXPRESS; Database=ConcurrencySampleDb; Trusted_Connection=True; MultipleActiveResultSets=true"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
