using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class HamburguesaConfiguration : IEntityTypeConfiguration<Hamburguesa>
    {
        public void Configure(EntityTypeBuilder<Hamburguesa> builder)
        {
            builder.ToTable("hamburguesa");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
            .IsRequired()
            .HasColumnName("IdHamburguesa");

            builder.Property(r => r.Nombre)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("NombreHamburguesa");

            builder.Property(r => r.Precio)
            .IsRequired()
            .HasColumnName("PrecioHamburguesa");

            builder
            .HasMany(r => r.Ingredientes)
            .WithMany(p => p.Hamburguesas)
            .UsingEntity<HamburguesaIngrediente>(

                j => j
                .HasOne(pt => pt.Ingrediente)
                .WithMany(t => t.HamburguesaIngredientes)
                .HasForeignKey(ut => ut.IngredienteId),

                j => j
                .HasOne(et => et.Hamburguesa)
                .WithMany(e => e.HamburguesaIngredientes)
                .HasForeignKey(te => te.HamburguesaId),

                j =>
                {
                    j.ToTable("hamburguesa_ingrediente");
                    j.HasKey(t => new{t.HamburguesaId, t.IngredienteId});
                }
            );
        }
    }
}