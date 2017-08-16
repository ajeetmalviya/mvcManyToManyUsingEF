using IMDB.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace IMDB.DAL.Models.Mapping
{
    public class ProducerMap : EntityTypeConfiguration<Producer>
    {
        public ProducerMap()
        {
            // Primary Key
            this.HasKey(t => t.ProducerId);

            // Properties
            this.Property(t => t.ProducerName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Bio)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Producers");
            this.Property(t => t.ProducerId).HasColumnName("ProducerId");
            this.Property(t => t.ProducerName).HasColumnName("ProducerName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.DOB).HasColumnName("DOB");
            this.Property(t => t.Bio).HasColumnName("Bio");
        }
    }
}
