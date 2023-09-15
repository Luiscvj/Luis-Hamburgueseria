using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IHamburguesa_Ingrediente :IGenericRepositoryH_I<Hamburguesa_Ingrediente>
{
   int EncontrarHamburguesayMasIngrediente(string NombreAmburguesa);
}