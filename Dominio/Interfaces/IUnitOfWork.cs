

namespace Dominio.Interfaces;

    public interface IUnitOfWork
    {
        public ICategoria Categorias {get;}
        public IHamburguesa Hamburguesas {get;}
        public IHamburguesa_Ingrediente Hamburguesa_Ingredientes {get;}
        public IChef Chefs {get;}
        public IIngrediente Ingredientes {get;}
       
        Task<int> SaveAsync();
    }

