using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class Hamburguesa_IngredienteConfiguration : IEntityTypeConfiguration<Hamburguesa_Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Hamburguesa_Ingrediente> builder)
        {
            // Configure entity here
               builder.ToTable("hamburguesa_ingrediente");

               
        }
    }