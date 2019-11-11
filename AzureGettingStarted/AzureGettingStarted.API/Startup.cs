using System;
using System.Net.Http.Headers;
using AzureGettingStarted.Repository;
using AzureGettingStarted.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AzureGettingStarted.API
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
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddHttpClient<VisionService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["VisionFunctionUrl"]);
            });
            services.AddHttpClient<BlobService>(client =>
            {
                client.BaseAddress = new Uri(
                    Configuration["BlobAdress"]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedKey", Configuration["BlobSharedKey"]);
            });
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
