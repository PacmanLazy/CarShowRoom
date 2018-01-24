using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShowRoom.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("MySqlServer");
            services.AddDbContext<CarShowRoomContext>(options =>
                options.UseMySql(connection));

            services.AddMvc()
                .AddSessionStateTempDataProvider();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/");
                routes.MapRoute(
                    name: "cars",
                    template: "{controller=Car}/{action=All}/{Id?}");
            });
        }
    }
}
