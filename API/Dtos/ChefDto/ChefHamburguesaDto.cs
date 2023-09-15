using API.Dtos.HamburguesaDto;

namespace API.Dtos.ChefDto;

public class ChefHamburguesaDto{
 public string Nombre { get; set; }
 public List<HamburguesaNombreDto> Hamburguesas { get; set; }

}