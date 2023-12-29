using System.Collections.Generic;

namespace Galytix.WebApi.Services
{
    public interface IGwpDataService
    {
        Dictionary<string, Dictionary<string, decimal>> LoadDataFromCsv(string filePath);
    }

    public class GwpDataService : IGwpDataService
    {
        public Dictionary<string, Dictionary<string, decimal>> LoadDataFromCsv(string filePath)
        {
            
            var data = new Dictionary<string, Dictionary<string, decimal>>
            {
                {
                    "ae", new Dictionary<string, decimal>
                    {
                        { "property", 1000000M },
                        { "transport", 2000000M }
                        
                    }
                },
               
            };

            return data;
        }
    }
}
using Galytix.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Galytix.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGwpDataService, GwpDataService>(); 
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IGwpDataService gwpDataService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Load data on application startup
            var filePath = "../Galytix.WebApi (4)/Data/gwpByCountry.csv";
            var gwpData = gwpDataService.LoadDataFromCsv(filePath);

           
            
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
