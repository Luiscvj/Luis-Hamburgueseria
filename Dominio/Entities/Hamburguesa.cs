namespace Dominio.Entities;

public class Hamburguesa : BaseEntity
{
    public string Nombre { get; set; }
    public int Precio { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public int ChefId { get; set; }
    public Chef Chef { get; set; }
    public List<Hamburguesa_Ingrediente> Hamburguesa_Ingredientes { get; set; }
    public List<Ingrediente> Ingredientes { get; set; }
}
