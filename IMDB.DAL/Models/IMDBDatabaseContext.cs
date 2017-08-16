using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using IMDB.DAL.Models.Mapping;
using IMDB.Entities.Models;

namespace IMDB.DAL.Models
{
    public partial class IMDBDatabaseContext : DbContext
    {
        static IMDBDatabaseContext()
        {
            Database.SetInitializer<IMDBDatabaseContext>(null);
        }

        public IMDBDatabaseContext()
            : base("Name=IMDBDatabaseContext")
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ActorMap());
            modelBuilder.Configurations.Add(new MovieMap());
            modelBuilder.Configurations.Add(new ProducerMap());
        }
    }
}
