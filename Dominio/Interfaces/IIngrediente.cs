
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IIngrediente : IGenericRepository<Ingrediente>
{
    Task<IEnumerable<Ingrediente>> StockMas400();
    Task<Ingrediente> IngredienteMasCaro();
    int  ActualizarDescripcionPan();
    Task<IEnumerable<Ingrediente>>  PrecioRango();
}