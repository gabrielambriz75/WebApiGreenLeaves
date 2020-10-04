using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiGreenLeaves.Data;
using WebApiGreenLeaves.Repository;
using WebApiGreenLeaves.Repository.IRepository;

namespace WebApiGreenLeaves
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
            services.AddScoped<IRegionsRepository, RegionsRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();


            services.AddDbContext<GreenLeavesContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("GreenLeavesConnection")));
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ApiFormulario", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "GreenLeaves API ",
                    Description = "Api general para para el formulario de GreenLeaves",
                    Version = "1.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "angelgabrielda@hotmail.com",
                        Name = "Angel Gabriel Dominguez Ambriz",
                        Url = new Uri("https://github.com/gabrielambriz75")
                    },
                   

                });



                var XMLComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var APIRutaComentarios = Path.Combine(AppContext.BaseDirectory, XMLComentarios);
                options.IncludeXmlComments(APIRutaComentarios);
            });

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
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/ApiFormulario/swagger.json", "API");

                options.RoutePrefix = "";

            });

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
