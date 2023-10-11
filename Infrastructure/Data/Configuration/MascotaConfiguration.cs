using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
{

public void Configure(EntityTypeBuilder<Mascota> builder)
{
    builder.ToTable("Mascota");


    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id);

    builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);
    
    builder.Property(p => p.FechaNacimiento)
        .HasColumnType("datetime");

    builder.HasOne(p => p.clientes)
        .WithMany(e => e.mascotas)
        .HasForeignKey(f => f.IdCliente);
    


    builder.HasOne(p => p.Raza)
        .WithOne(e => e.Mascotas)
        .HasForeignKey<Mascota>(f => f.IdRaza);

}
}
}