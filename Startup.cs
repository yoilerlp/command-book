using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Comandos.Data;
using Microsoft.EntityFrameworkCore;

namespace Comandos
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


            const string herokuConnectionString = @"
                            Host=ec2-52-203-74-38.compute-1.amazonaws.com;
                            Port=5432;
                            Username=ktmlhomnyvkjcx;
                            Password=b4123ddb9fe4ad445e5150c989e83df1d8a79a8f32eee2b16737c00488292674;
                            Database=d1rhq2nuj2ldn0;
                            Pooling=true;
                            SSL Mode=Require;
                            TrustServerCertificate=True;
                        ";

                        
            services.AddDbContext<CommanderContext>(opt => {
                opt.UseNpgsql(herokuConnectionString);
            });

            services.AddScoped<ICommanderRepo, SqlCommanderRepo>();
            services.AddScoped<IPlatformRepo, SqlPlatformRepo>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Comandos", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Comandos v1"));
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
