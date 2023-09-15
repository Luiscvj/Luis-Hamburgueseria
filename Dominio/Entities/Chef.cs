namespace Dominio.Entities;

public class Chef : BaseEntity
{
    public string Nombre { get; set; }
    public string   Especialidad { get; set; }
    public List<Hamburguesa> Hamburguesas { get; set; }
}