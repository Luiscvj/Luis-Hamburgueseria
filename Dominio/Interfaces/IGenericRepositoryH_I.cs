

using Dominio.Entities;
namespace Dominio.Interfaces;
using System.Linq.Expressions;
public interface IGenericRepositoryH_I<Hamburguesa_Ingrediente>
{
    Task<Hamburguesa_Ingrediente> GetByIdAsync(int HamburgesaId,int IngredienteId);
    Task<IEnumerable<Hamburguesa_Ingrediente>> GetAllAsync();
    IEnumerable<Hamburguesa_Ingrediente> Find(Expression<Func<Hamburguesa_Ingrediente, bool>> expression);
    Task<(int totalRegistros, IEnumerable<Hamburguesa_Ingrediente> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(Hamburguesa_Ingrediente  entity);
    void AddRange(IEnumerable<Hamburguesa_Ingrediente> entities);
    void Remove(Hamburguesa_Ingrediente  entity);
    void RemoveRange(IEnumerable<Hamburguesa_Ingrediente> entities);
    void Update(Hamburguesa_Ingrediente entity);
}

