using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aplicacao_com_service.Data;
using aplicacao_com_service.Service;

namespace aplicacao_com_service
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
            services.AddControllersWithViews();

            string mySqlConnection = Configuration.GetConnectionString("aplicacao_com_serviceContext");

            services.AddDbContext<aplicacao_com_serviceContext>(options =>
                    options.UseMySql(mySqlConnection,ServerVersion.AutoDetect(mySqlConnection)));

            services.AddScoped<SeedingService>();
            services.AddScoped<ConvenioService>();
            services.AddScoped<MedicoService>();
            services.AddScoped<EspecialidadeService>();
            services.AddScoped<PacienteService>();
            services.AddScoped<ProcedimentoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

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
