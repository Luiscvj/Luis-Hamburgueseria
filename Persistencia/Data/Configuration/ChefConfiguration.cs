using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class ChefConfiguration : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            // Configure entity here
               builder.ToTable("chef");

               builder.Property(x => x.Especialidad)
                       .HasMaxLength(130);
               
        }
    }