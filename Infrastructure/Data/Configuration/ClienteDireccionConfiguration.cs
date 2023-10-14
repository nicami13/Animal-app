using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
public class ClienteDireccionConfiguration : IEntityTypeConfiguration<ClienteDireccion>
{

public void Configure(EntityTypeBuilder<ClienteDireccion> builder)
{
    builder.ToTable("ClienteDireccion");


    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id);

    builder.Property(p => p.NumeroPri)
        .HasColumnType("int")
        .HasMaxLength(3);
    
    builder.Property(p => p.Letra)
        .IsRequired()
        .HasMaxLength(2);
    
    builder.Property(p => p.Bis)
        .IsRequired()
        .HasMaxLength(3);
    
    builder.Property(p => p.LetraSec)
        .IsRequired()
        .HasMaxLength(2);
    
    builder.Property(p => p.Cardinal)
        .IsRequired()
        .HasMaxLength(4);
    
    builder.Property(p => p.NumeroSec)
        .HasColumnType("int")
        .HasMaxLength(3);
    
    builder.Property(p => p.NumeroTer)
        .HasColumnType("int")
        .HasMaxLength(3);

    builder.Property(p => p.CardinalSec)
    .IsRequired()
    .HasMaxLength(4);

    builder.Property(p => p.CodigoPostal)
        .IsRequired()
        .HasMaxLength(20);
    
    builder.Property(p => p.Provincia)
        .IsRequired()
        .HasMaxLength(50);

    builder.HasOne(p => p.Clientes)
        .WithOne(e => e.ClienteDireccion)
        .HasForeignKey<ClienteDireccion>(f => f.IdCliente);
    
    builder.HasOne(p => p.Ciudades)
        .WithOne(e => e.ClienteDireccion)
        .HasForeignKey<ClienteDireccion>(f => f.IdCiudad);

}
}
}