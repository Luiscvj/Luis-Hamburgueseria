using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class HamburguesaRepository : GenericRepository<Hamburguesa>, IHamburguesa
{
    private HamburgueseriaContext _context;
    public HamburguesaRepository(HamburgueseriaContext context) : base(context)
    {
        _context = context;
    }

    public async  Task<IEnumerable<Ingrediente>> GetHamburgesasPanIntegral()
    {
        var result = await   _context.Ingredientes.Where(x => x.Nombre == "Pan Integral").Include(x => x.Hamburguesas).ToListAsync();
                                               

        return result;
    }

    public async Task<IEnumerable<Hamburguesa>> GetHamburgesasPrecioRango()
    {
         return   await _context.Hamburguesas.Where( c => c.Precio <= 9).ToListAsync();
                                            

         

    }

    public async  Task<IEnumerable<Hamburguesa>> GetHamburgesasVegetarianas()
    {
      

          return await  _context.Hamburguesas.Where( hamburguesa => hamburguesa.CategoriaId == 7).ToListAsync();
                                                                          

      
    }

    public async Task<IEnumerable<Hamburguesa>> GetHamburguesaAscendingByPrice()
    {
        return await _context.Hamburguesas.OrderBy(x =>x.Precio).ToListAsync();
    }


        public override async Task<(int totalRegistros,IEnumerable<Hamburguesa> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Hamburguesas as IQueryable<Hamburguesa>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Ingredientes)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}