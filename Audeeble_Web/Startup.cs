using Audeeble_Shared.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Audeeble_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Méthode appelée par le runtime.
        /// Utiliser cette méthode pour ajouter des services au conteneur.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Options
            services.AddOptions();
            services.Configure<OptionsAPI>(this.Configuration.GetSection("ApiSettings"));
            
            // Désactivation des EndPoint pour utiliser les routes standards
            // Activation de MVC en version 3.0
            services
                .AddMvc(options => 
                {
                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        /// <summary>
        /// Méthode appelée par le runtime.
        /// Utiliser cette méthode pour configurer le flux d'une requête HTTP.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Gestion des erreurs
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Activation de la redirection vers HTTPS
            app.UseHttpsRedirection();

            // Utilisation des fichiers statiques
            app.UseStaticFiles();

            // Utilisation des autorisations
            app.UseAuthorization();

            // Configuration des routes
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Tiers}/{action=Index}/{id?}"
                );
            });
        }
    }
}