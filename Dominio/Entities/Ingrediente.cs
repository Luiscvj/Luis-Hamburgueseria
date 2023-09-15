namespace Dominio.Entities;

public class Ingrediente : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Precio { get; set; } 
    public int Stock{ get; set; }
    public List<Hamburguesa_Ingrediente> Hamburguesa_Ingredientes { get; set; }
    public List<Hamburguesa> Hamburguesas { get; set; }
}