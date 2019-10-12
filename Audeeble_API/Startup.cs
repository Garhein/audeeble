using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
        /// M�thode appel�e par le runtime.
        /// Utiliser cette m�thode pour ajouter des services au conteneur.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Base de donn�es
            services.AddDbContext<AudeebleContextDB>(
                options => options.UseSqlServer(this.Configuration["AudeebleContextDB"]));
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