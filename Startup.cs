using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OpheliaSuiteV2.Core.SSB.Lib.Filters;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;
using PruebasDeConexion.DI;
using OpheliaSuiteV2.Core.SSB.Lib;

namespace PruebasDeConexion
{
    public class Startup
    {

        #region BProperties
        public static IConfiguration Configuration { get; private set; }
        #endregion

        #region Builders

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Metodhs


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            //AddSwagger(services);

            //Default_CorsPolicy
            services.AddCors(opt =>
            {
                opt.AddPolicy("Default_CorsPolicy", o =>
                {
                    o.AllowAnyHeader();
                    o.AllowAnyMethod();
                    o.AllowAnyOrigin();
                });
            });
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LanguageFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMvc(option => option.EnableEndpointRouting = false);


            //configuracion de Sagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "DigitalWare - API Klinic",
                    Version = "v1",
                    Description = "Api Backend con la finalidad de exponer servicios para las funcionalidades de procesos hospitalarios",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Ophelia Suite",
                        Url = "http://www.digitalware.com.co"
                    }
                });
                //Agregando comentarios Xml a la documentación
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Cargamos la cadena de conexión       

            
            services.AddDbContext<DbContext>(options => options.UseSqlServer("DbSetting"));

            DependencyInjectionProfile.RegisterProfile(services);
            
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("Default_CorsPolicy");
            app.UseMvc();

            //Hacemos disponible el contenedor de dependencias
            Globals.ServiceProvider = app.ApplicationServices;

            //Obtenemos el nombre de la aplicación URL
            string appNameURI = Configuration.GetValue<string>("AppNameURI")?.Trim() ?? "/";
            appNameURI = (!appNameURI.StartsWith("/") ? ("/" + appNameURI) : appNameURI);
            appNameURI = (!appNameURI.EndsWith("/") ? (appNameURI + "/") : appNameURI);

            string swaggerEndPoint = $"{appNameURI}swagger/v1/swagger.json";           

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "api";
                s.SwaggerEndpoint(swaggerEndPoint, "Example Template API Documentation V1");
            });
        }
    }

    #endregion





}
