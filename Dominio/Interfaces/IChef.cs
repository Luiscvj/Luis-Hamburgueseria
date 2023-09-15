using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IChef : IGenericRepository<Chef>
{
    Task<IEnumerable<Chef>> GetChefDeCarnes();
    Task<IEnumerable<Chef>> GetHamburguesasEchasPorChef(string Nombre);
}