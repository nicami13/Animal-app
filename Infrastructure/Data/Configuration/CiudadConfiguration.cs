using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{

public void Configure(EntityTypeBuilder<Ciudad> builder)
{
    builder.ToTable("Ciudad");


    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id);

    builder.Property(p => p.NombreCiudad)
        .IsRequired()
        .HasMaxLength(50);
    
    builder.HasOne(p => p.Departamentos)
        .WithMany(e => e.Ciudades)
        .HasForeignKey(f => f.IdDepartamento);

}
}
}