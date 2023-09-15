namespace Dominio.Entities;

public class Ingrediente : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Precio { get; set; }
    public int Stock { get; set; }

    public ICollection<Hamburguesa> Hamburguesas { get; set; } = new HashSet<Hamburguesa>();
    public ICollection<HamburguesaIngrediente> HamburguesaIngredientes { get; set; }
}