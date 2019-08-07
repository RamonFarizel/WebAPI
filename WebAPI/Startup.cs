using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPI.Models.Context;
using WebAPI.Business;
using WebAPI.Business.Implementations;
using WebAPI.Repository.Implementations;
using WebAPI.Repository;
using WebAPI.Repository.Generic;

namespace WebAPI
{
    public class Startup
    {
      
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
          
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //preparando banco de dados.
            var connectionString = _configuration["ConnectionStrings:BaseExemplo"];
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddApiVersioning();

            //Injeção de dependência.
            services.AddScoped<IPersonBusiness, PersonBusinessImp>();
            services.AddScoped<IBookBusiness, BookBusinessImp>();

            services.AddScoped<IPersonRepository, PersonRepositoryImp>();

            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
