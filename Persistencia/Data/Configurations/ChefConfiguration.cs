using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class ChefConfiguration : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.ToTable("chef");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
            .IsRequired()
            .HasColumnName("IdChef");

            builder.Property(r => r.Nombre)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("NombreChef");

            builder.Property(r => r.Especialidad)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("EspecialidadChef");
        }
    }
}