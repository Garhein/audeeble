using Audeeble_Shared.Entity.Tiers;
using Microsoft.EntityFrameworkCore;

namespace Audeeble_API
{
    /// <summary>
    /// Contexte de la base de données.
    /// </summary>
    public class AudeebleContextDB : DbContext
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="options"></param>
        public AudeebleContextDB(DbContextOptions<AudeebleContextDB> options) : base(options) { }

        #region Tiers

        public DbSet<ViewListeTiers> Tiers { get; set; }
        
        public DbSet<Personne> Personnes { get; set; }

        public DbSet<PersonneMorale> PersonnesMorales { get; set; }

        public DbSet<PersonnePhysique> PersonnesPhysiques { get; set; }

        public DbSet<Civilite> Civilites { get; set; }

        #endregion
    }
}
