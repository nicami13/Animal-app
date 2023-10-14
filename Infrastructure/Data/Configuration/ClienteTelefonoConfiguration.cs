using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
public class ClienteTelefonoConfiguration : IEntityTypeConfiguration<ClienteTelefono>
{

public void Configure(EntityTypeBuilder<ClienteTelefono> builder)
{
    builder.ToTable("ClienteTelefono");


    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id);

    builder.Property(p => p.Numero)
        .IsRequired()
        .HasMaxLength(30);

    builder.HasOne(p => p.Clientes)
        .WithMany(e => e.ClienteTelefonos)
        .HasForeignKey(f => f.IdCliente);

}
}
}