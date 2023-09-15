
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Seeding;

    public class SeedingInitial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {


            var chef1 = new Chef {Id =1, Nombre ="Gustov", Especialidad ="Carnes"};
            var chef2 = new Chef {Id =2,Nombre ="Marco", Especialidad ="Parrilla"};
            var chef3 = new Chef {Id =3,Nombre ="Antonio", Especialidad ="Salsas"};


            var categoria1 = new Categoria { Id =7, Nombre ="Vegetariana" ,Descripcion ="Hamburguesas sin carnes"};
            var categoria2 = new Categoria { Id =2, Nombre ="Quesuda" ,Descripcion ="Hamburguesas con mas de dos tipos de queso"};
            var categoria3 = new Categoria { Id =3, Nombre ="Doble Carne" ,Descripcion ="Hamburguesas gourmet  con carne angus"};
            var categoria4= new Categoria { Id =8, Nombre ="Comunes" ,Descripcion ="Hamburguesas gourmet  con carne angus"};

            var ingrediente1 =new Ingrediente {Id =1 , Nombre= "Lechuga",Descripcion="Vegetal", Precio= 2, Stock =1000};
            var ingrediente2 =new Ingrediente {Id =2 , Nombre= "Pan Integral",Descripcion="Pan", Precio= 4, Stock =3000};
            var ingrediente3 =new Ingrediente {Id =3 , Nombre= "Carne",Descripcion="Carne Angus", Precio= 10, Stock =2000};
           
            var hamburguesa1 = new Hamburguesa { Id =1 , Nombre = "La Poporra", CategoriaId =categoria3.Id,Precio=15, ChefId =chef1.Id};
            var hamburguesa2 = new Hamburguesa { Id = 2, Nombre = "La verde", CategoriaId =categoria1.Id,Precio=12, ChefId =chef2.Id};
            var hamburguesa3 = new Hamburguesa { Id = 10, Nombre = "Clasica", CategoriaId =categoria4.Id,Precio=12, ChefId =chef2.Id};

            var hamburguesa_ingrediente1 = new Hamburguesa_Ingrediente {HamburguesaId = hamburguesa1.Id,IngredienteId =ingrediente3.Id};
            var hamburguesa_ingrediente2 = new Hamburguesa_Ingrediente {HamburguesaId = hamburguesa2.Id,IngredienteId =ingrediente1.Id};
        
            modelBuilder.Entity<Chef>().HasData(chef1, chef2, chef3);
            modelBuilder.Entity<Categoria>().HasData(categoria1, categoria2, categoria3,categoria4);
            modelBuilder.Entity<Ingrediente>().HasData(ingrediente1, ingrediente2, ingrediente3);
            modelBuilder.Entity<Hamburguesa>().HasData(hamburguesa1, hamburguesa2,hamburguesa3);
            modelBuilder.Entity<Hamburguesa_Ingrediente>().HasData(hamburguesa_ingrediente1, hamburguesa_ingrediente2);
   
        } 
      }
    