using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
        /// M�thode appel�e par le runtime.
        /// Utiliser cette m�thode pour ajouter des services au conteneur.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Prise en charge des contr�leurs et des vues associ�es
            // Remplace services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddControllersWithViews();
        }

        /// <summary>
        /// M�thode appel�e par le runtime.
        /// Utiliser cette m�thode pour configurer le flux d'une requ�te HTTP.
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

            // Utilisation des routes
            app.UseRouting();

            // Utilisation des autorisations
            app.UseAuthorization();

            // Configuration des routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}