using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class IngredienteConfiguration : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            // Configure entity here
               builder.ToTable("ingrediente");

               builder.Property(x => x.Nombre)
                       .HasMaxLength(130);

               builder.Property(x => x.Descripcion)
                       .HasMaxLength(250);
               builder.Property(x => x.Precio)
                       .HasPrecision(10,3);
               builder.Property(x => x.Stock)
                       .HasColumnType("int")
                       .HasMaxLength(11);
               
               
               
               
        }
    }