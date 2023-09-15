using System.Reflection;
using Dominio.Entities;
using Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;

public class HamburgueseriaContext : DbContext
{
    public HamburgueseriaContext(DbContextOptions<HamburgueseriaContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder modelBuilder)
    {
        modelBuilder.Properties<string>().HaveMaxLength(100);
        
    }

    public DbSet<Hamburguesa_Ingrediente> Hamburguesa_Ingredientes { get; set; }
    public DbSet<Hamburguesa> Hamburguesas { get; set; }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SeedingInitial.Seed(modelBuilder);

    }
}