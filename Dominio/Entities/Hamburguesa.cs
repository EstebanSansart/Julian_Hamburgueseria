namespace Dominio.Entities;
public class Hamburguesa : BaseEntity
{
    public int Precio { get; set; }

    public int ChefId { get; set; }
    public Chef Chef { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    public ICollection<Ingrediente> Ingredientes { get; set; } = new HashSet<Ingrediente>();
    public ICollection<HamburguesaIngrediente> HamburguesaIngredientes { get; set; }
}