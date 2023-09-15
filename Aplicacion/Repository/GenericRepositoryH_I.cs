using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class GenericRepositoryH_I : IGenericRepositoryH_I<Hamburguesa_Ingrediente>
{
     private  readonly HamburgueseriaContext _context;

    public GenericRepositoryH_I (HamburgueseriaContext context)
    {
        _context = context;
    }


    public virtual void Add(Hamburguesa_Ingrediente entity)
    {
        _context.Set<Hamburguesa_Ingrediente>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<Hamburguesa_Ingrediente> entities)
    {
       _context.Set<Hamburguesa_Ingrediente>().AddRange(entities);
    }

    public virtual IEnumerable<Hamburguesa_Ingrediente> Find(Expression<Func<Hamburguesa_Ingrediente, bool>> expression)
    {
         return _context.Set<Hamburguesa_Ingrediente>().Where(expression);
    }

    public virtual async Task<IEnumerable<Hamburguesa_Ingrediente>> GetAllAsync()
    {
        return await _context.Set<Hamburguesa_Ingrediente>().ToListAsync();
    }

    public virtual async Task<(int totalRegistros, IEnumerable<Hamburguesa_Ingrediente> registros)> GetAllAsync(int pageIndex, int pageSize)
    {
         var totalRegistros = await _context.Set<Hamburguesa_Ingrediente>().CountAsync();
        var registros = await _context.Set<Hamburguesa_Ingrediente>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual async Task<Hamburguesa_Ingrediente> GetByIdAsync(int HamburgesaId, int IngredienteId)
    {
        return await _context.Set<Hamburguesa_Ingrediente>().Where(x => x.IngredienteId == IngredienteId && x.HamburguesaId == HamburgesaId).FirstOrDefaultAsync();
    }

    public virtual void Remove(Hamburguesa_Ingrediente entity)
    {
         _context.Set<Hamburguesa_Ingrediente>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Hamburguesa_Ingrediente> entities)
    {
       _context.Set<Hamburguesa_Ingrediente>().RemoveRange(entities);
    }

    public virtual void Update(Hamburguesa_Ingrediente entity)
    {
          _context.Set<Hamburguesa_Ingrediente>()
            .Update(entity);
    }
}

