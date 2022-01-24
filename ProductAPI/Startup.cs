using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Repository.IRepository;
using ProductAPI.Repository;
using ProductAPI.Models;
using ProductAPI.Models.DTO;

namespace ProductAPI
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
            services.AddDbContext<ApplicationDbContext>(option => 
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConectionString")));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddAutoMapper( configuration =>
            {

                configuration.CreateMap<Product, ProductDTO>();
                configuration.CreateMap<ProductDTO, Product>();
            }, typeof(Startup) );


            services.AddControllers();
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
