using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class HamburguesaConfiguration : IEntityTypeConfiguration<Hamburguesa>
    {
        public void Configure(EntityTypeBuilder<Hamburguesa> builder)
        {
            // Configure entity here
               builder.ToTable("hamburguesa");

               builder.Property(x => x.Nombre)
                       .HasMaxLength(130);
               builder.Property(x => x.Precio)
                       .HasColumnType("int")
                       .HasMaxLength(11);

                builder.HasOne(x => x.Categoria)
                    .WithMany(x => x.Hamburguesas)
                    .HasForeignKey(x => x.CategoriaId);

                builder.HasOne(x => x.Chef)
                    .WithMany(x => x.Hamburguesas)
                    .HasForeignKey(x => x.ChefId);

                    builder.HasMany(x => x.Ingredientes)
                        .WithMany(x => x.Hamburguesas)
                        .UsingEntity<Hamburguesa_Ingrediente>();
                    
                
                
               
               
        }
    }