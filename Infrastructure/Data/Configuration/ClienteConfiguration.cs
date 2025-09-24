using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(50);

            builder.Property(p => p.Apellido).IsRequired().HasMaxLength(50);

            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        }
    }
}
