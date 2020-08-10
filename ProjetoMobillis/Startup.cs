using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoMobills.Data;
using ProjetoMobills.Data.Respository;
using ProjetoMobills.Data.Respository.Implement;
using System;

namespace ProjectMobills
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
            var SqlConnectionConfiguration = new SqlConfiguracaoConexao(Configuration.GetConnectionString("SQLDbContext"));
            services.AddSingleton(SqlConnectionConfiguration);

            services.AddTransient<IDespesaRepository, DespesaRespository>();
            services.AddTransient<IReceitaRepository, ReceitaRepository>();

            services.AddControllers()
                .AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API PROJETO MOBILLS",
                    Version = "v1",
                    Description = "Api feita para processo seletivo da Mobills",
                    Contact = new OpenApiContact
                    {
                        Name = "Diego Wenndson",
                        Email = "diego.wenndson@gmail.com",
                        Url = new Uri("https://github.com/dwenndson")
                    }
                });
            });
       

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Mob API V1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
