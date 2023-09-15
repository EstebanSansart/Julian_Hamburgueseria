using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
            .IsRequired()
            .HasColumnName("IdCategoria");

            builder.Property(r => r.Nombre)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("NombreCategoria");

            builder.Property(r => r.Descripcion)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("DescripcionCategoria");
        }
    }
}