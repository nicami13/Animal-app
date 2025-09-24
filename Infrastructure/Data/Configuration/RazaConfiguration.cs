using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RazaConfiguration : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            builder.ToTable("Raza");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(r => r.NombreRaza).IsRequired().HasMaxLength(50);
        }
    }
}
