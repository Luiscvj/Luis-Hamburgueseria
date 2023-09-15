using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class IngredienteRepository : GenericRepository<Ingrediente>, IIngrediente
{
    private HamburgueseriaContext _context;
    public IngredienteRepository(HamburgueseriaContext context) : base(context)
    {
        _context = context;
    }

    public int  ActualizarDescripcionPan()
    {
            var ingrediente =  _context.Ingredientes.FirstOrDefault(x => x.Descripcion.Contains("Pan"));
            return ingrediente.Id;

    }

    public async  Task<Ingrediente> IngredienteMasCaro()
    {
         var result = _context.Ingredientes.Max(x => x.Precio);

         return await _context.Ingredientes.FirstOrDefaultAsync(x => x.Precio == result);
    }

    public async Task<IEnumerable<Ingrediente>> PrecioRango()
    {
        return await _context.Ingredientes.Where(c => c.Precio >= 2 && c.Precio <= 5).ToListAsync();
    }

    public async Task<IEnumerable<Ingrediente>> StockMas400()
    {
        return await _context.Ingredientes.Where(ingrediente => ingrediente.Stock > 400).ToListAsync();
    }


       public override async Task<(int totalRegistros,IEnumerable<Ingrediente> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Ingredientes as IQueryable<Ingrediente>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Hamburguesas)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}