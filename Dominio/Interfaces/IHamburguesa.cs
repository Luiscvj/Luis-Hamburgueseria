using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IHamburguesa : IGenericRepository<Hamburguesa>
{
    Task<IEnumerable<Hamburguesa>> GetHamburgesasVegetarianas();
    Task<IEnumerable<Hamburguesa>> GetHamburgesasPrecioRango();
    Task<IEnumerable<Hamburguesa>> GetHamburguesaAscendingByPrice();
    Task<IEnumerable<Ingrediente>> GetHamburgesasPanIntegral();

    Task<IEnumerable<Hamburguesa>> GetHambirguesasSinQuesoCheddar();

    
}