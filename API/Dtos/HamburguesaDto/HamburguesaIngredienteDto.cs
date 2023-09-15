using API.Dtos.IngredienteDto;

namespace API.Dtos.HamburguesaDto;


public class HamburguesaIngredienteDto
{
    public string Nombre { get; set; }
    public int Precio { get; set; }
    public int CategoriaId { get; set; }
    public int ChefId { get; set; }
    public List<IngredienteNombreDto> Ingredientes { get; set; }
   
}