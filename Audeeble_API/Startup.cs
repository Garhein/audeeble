using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Audeeble_API
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
            services.AddControllers();
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

            // Activation de la redirection vers HTTPS
            app.UseHttpsRedirection();

            // Utilisation des routes
            app.UseRouting();

            // Utilisation des autorisations
            app.UseAuthorization();

            // Configuration des routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}