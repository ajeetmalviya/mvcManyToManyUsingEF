using IMDB.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace IMDB.DAL.Models.Mapping
{
    public class ActorMap : EntityTypeConfiguration<Actor>
    {
        public ActorMap()
        {
            // Primary Key
            this.HasKey(t => t.ActorId);

            // Properties
            this.Property(t => t.ActorName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Bio)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Actors");
            this.Property(t => t.ActorId).HasColumnName("ActorId");
            this.Property(t => t.ActorName).HasColumnName("ActorName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.DOB).HasColumnName("DOB");
            this.Property(t => t.Bio).HasColumnName("Bio");

            // Relationships
            this.HasMany(t => t.Movies)
                .WithMany(t => t.Actors)
                .Map(m =>
                    {
                        m.ToTable("MovieActorRelationship");
                        m.MapLeftKey("ActorId");
                        m.MapRightKey("MovieId");
                    });


        }
    }
}
