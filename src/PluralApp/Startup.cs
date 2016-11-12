using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using PluralApp.Services;
using PluralApp.Entites;
using Microsoft.EntityFrameworkCore;

namespace PluralApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                                                    .AddJsonFile("appsettings.json");
                                                    //can add as many conf af pleased

           Configuration =  builder.Build();
        }
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //when adding new services, need to register it here
            //This is for each client new instance of the srvice
            //services.AddTransient
            //For each http request new instanvce
            // services.AddScope
            services.AddSingleton<IGreeder, Greeder>();
            services.AddSingleton(Configuration);
            services.AddMvc();

            services.AddScoped<IItemData, SqlItemData>();
            //configuring db
            services.AddDbContext<ITemsProjectDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Azure")));

        }

        // This method gets called by the runtime. 
        //Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IGreeder greet)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                //handle errors in production envoirment, when exception redirect
                app.UseExceptionHandler(new ExceptionHandlerOptions {

                    ExceptionHandlingPath = "/error"

                });

            }
            //this would serve default files
            //app.UseDefaultFiles();
             
            //Use static files

            app.UseStaticFiles();
            app.UseMvc(configureRoutes);
            app.Run(ctx => ctx.Response.WriteAsync("Not Found"));
            /* example of the middleware
          app.UseWelcomePage(new WelcomePageOptions {

              Path = "/welcome"

          });
          

          app.Run(async (context) =>
          {
              //taking directly value from the json
              //var message = Configuration["Greetings"];
            //  throw new Exception("Boom!");
              var message = greet.GetGreeding();
              await context.Response.WriteAsync(message);
          });*/

        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            //home/index ? - element is optional, = default cont/ action
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
