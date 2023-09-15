using Dominio.Entities;
using Dominio.Interfaces;
using iText.StyledXmlParser.Jsoup.Parser;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;


public class Hamburguesa_IngredienteRepository : GenericRepositoryH_I,IHamburguesa_Ingrediente
{   
    private HamburgueseriaContext _context;
    public Hamburguesa_IngredienteRepository(HamburgueseriaContext context) : base(context)
    {
        _context = context;
    }

    public int EncontrarHamburguesayMasIngrediente(string NombreAmburguesa)
    {
      
            var HambruguesaId = from h in _context.Hamburguesas
                where h.Nombre == NombreAmburguesa
                select  h.Id;
           var nuevo = HambruguesaId.ToString();

           return Convert.ToInt16(nuevo);

         

        

       

    }




       public override async Task<(int totalRegistros,IEnumerable<Hamburguesa_Ingrediente> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Hamburguesa_Ingredientes as IQueryable<Hamburguesa_Ingrediente>;
      

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}