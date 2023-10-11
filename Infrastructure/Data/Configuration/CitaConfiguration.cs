using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{

public void Configure(EntityTypeBuilder<Cita> builder)
{
    builder.ToTable("cita");


    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id);

    builder.Property(p => p.Fecha)
        .HasColumnType("date");

    builder.Property(p => p.Hora)
        .HasColumnType("time");

    builder.HasOne(p => p.clientes)
        .WithMany(e => e.Citas)
        .HasForeignKey(f => f.IdCliente);
    
    builder.HasOne(p => p.Mascotas)
        .WithMany(e => e.Citas)
        .HasForeignKey(f => f.IdMascota);
    
    builder.HasOne(p => p.Servicios)
        .WithMany(e => e.citas)
        .HasForeignKey(f => f.IdServicio);
}
}
}