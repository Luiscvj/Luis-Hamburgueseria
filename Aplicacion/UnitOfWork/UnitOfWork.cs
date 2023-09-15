

using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
   

    private readonly HamburgueseriaContext _context;

    private CategoriaRepository _categoria ;
    private HamburguesaRepository _hamburguesa ;
    private IngredienteRepository _ingrediente ;
    private ChefRepository _chef;
    private Hamburguesa_IngredienteRepository _hamburguesa_ingrediente;

    public UnitOfWork(HamburgueseriaContext context)
    {
        _context = context;
    }

   public ICategoria Categorias
   {
       get
       {
           if (_categoria == null)
           {
               _categoria = new CategoriaRepository(_context);
           }
           return _categoria;
       }
   }

   public IHamburguesa Hamburguesas
   {
       get
       {
           if (_hamburguesa == null)
           {
               _hamburguesa = new HamburguesaRepository(_context);
           }
           return _hamburguesa;
       }
   }

 

   public IChef Chefs
   {
       get
       {
           if (_chef == null)
           {
               _chef = new ChefRepository(_context);
           }
           return _chef;
       }
   }

    public IIngrediente Ingredientes
    {
        get
        {
            if (_ingrediente == null)
            {
                _ingrediente = new IngredienteRepository(_context);
            }
            return _ingrediente;
        }
    }

 

    public IHamburguesa_Ingrediente Hamburguesa_Ingredientes
    {
        get
        {
            if (_hamburguesa_ingrediente == null)
            {
                _hamburguesa_ingrediente = new Hamburguesa_IngredienteRepository(_context);
            }
            return _hamburguesa_ingrediente;
        }
    }

   

    


    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

}