using IMDB.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace IMDB.DAL.Models.Mapping
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            // Primary Key
            this.HasKey(t => t.MovieId);

            // Properties
            this.Property(t => t.MoviesName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Plot)
                .HasMaxLength(1000);

            this.Property(t => t.Poster)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Movies");
            this.Property(t => t.MovieId).HasColumnName("MovieId");
            this.Property(t => t.MoviesName).HasColumnName("MoviesName");
            this.Property(t => t.YOR).HasColumnName("YOR");
            this.Property(t => t.Plot).HasColumnName("Plot");
            this.Property(t => t.Poster).HasColumnName("Poster");
            this.Property(t => t.ProducerId).HasColumnName("ProducerId");

            // Relationships
            this.HasRequired(t => t.Producer)
                .WithMany(t => t.Movies)
                .HasForeignKey(d => d.ProducerId);

        }
    }
}
