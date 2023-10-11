using Microsoft.EntityFrameworkCore;
using Core.Entities;
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

    builder.HasOne(p => p.Mascotas)
        .WithOne(e => e.Raza)
        .HasForeignKey<Raza>(f => f.NombreRaza);

}
}
}