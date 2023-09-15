using API.Dtos.HamburguesaDto;
namespace API.Dtos.CategoriaDto;
public class CategoriaHamburguesaDto
{

    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public List<HamburguesaNombreDto> Hamburguesas { get; set; }

}