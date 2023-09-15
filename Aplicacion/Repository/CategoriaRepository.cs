using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
    private HamburgueseriaContext _context;
    public CategoriaRepository(HamburgueseriaContext context) : base(context)
    {
        _context = context;
    }

    public async  Task<IEnumerable<Categoria>> GetGourmetDescripcion()
    {
        return await _context.Categorias.Where(c => c.Descripcion.Contains("Gourmet")).ToListAsync();
    }


        public override async Task<(int totalRegistros,IEnumerable<Categoria> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Categorias as IQueryable<Categoria>;
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