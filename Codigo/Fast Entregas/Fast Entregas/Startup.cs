using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fast_Entregas.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Services;

namespace Fast_Entregas
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("FastEntregasConnection")));
            services.AddDbContext<fast_entregasContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("FastEntregasConnection")));

            services.AddTransient<IGerenciadorVeiculo, GerenciadorVeiculo>();
            services.AddTransient<IGerenciadorContaBancaria, GerenciadorContaBancaria>();
            services.AddTransient<IGerenciadorCartao, GerenciadorCartao>();
            services.AddTransient<IGerenciadorUsuario, GerenciadorUsuario>();
            services.AddTransient<IGerenciadorSolicitacaoDeCadastro, GerenciadorSolicitacaoDeCadastro>();
            services.AddTransient<IGerenciadorBanco, GerenciadorBanco>();
            services.AddTransient<IGerenciadorEntrega, GerenciadorEntrega>();
            services.AddTransient<IGerenciadorFormaPagamento, GerenciadorFormaPagamento>();
            services.AddTransient<IGerenciadorFormaPagamentoHasEntrega, GerenciadorFormaPagamentoHasEntrega>();

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
