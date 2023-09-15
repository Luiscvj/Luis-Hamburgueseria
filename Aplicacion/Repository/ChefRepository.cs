using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class ChefRepository : GenericRepository<Chef>, IChef
{
    private HamburgueseriaContext _context;
    public ChefRepository(HamburgueseriaContext context) : base(context)
    {
        _context = context;
    }

    public async  Task<IEnumerable<Chef>> GetChefDeCarnes()
    {
        return await  _context.Chefs.Where(chef => chef.Especialidad == "Carnes").ToListAsync();
    }


     public async Task<IEnumerable<Chef>> GetHamburguesasEchasPorChef(string Nombre)
    {
      return   await  _context.Chefs.Where(c => c.Nombre == Nombre).Include(h => h.Hamburguesas).ToListAsync();
                    
        

        
    }



        public override async Task<(int totalRegistros,IEnumerable<Chef> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Chefs as IQueryable<Chef>;
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