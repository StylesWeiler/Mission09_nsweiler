using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission09_nsweiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940



        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }



        // allows the MVC pattern to be recognized
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllersWithViews();


            services.AddDbContext<BookstoreContext>(options => {
            
                options.UseSqlite(Configuration["ConnectionStrings:BookDbConnection"]);

            });

            // each HTTP request gets it own repository object and this decouples the object
            services.AddScoped<IBookRepository, EFBookRepository>();
        }
            

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // correspondes with the wwwroot
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // doex the same thing as we have done previously where we made an endpoint that takes us to the home controller, then the Index page
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
