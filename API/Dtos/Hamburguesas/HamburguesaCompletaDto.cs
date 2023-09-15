using Dominio.Entities;

namespace API.Dtos;
public class HamburguesaCompletaDto : HamburguesaDto
{
    public CategoriaDto Categoria { get; set; }
    public ChefDto Chef { get; set; }
    public List<IngredienteDto> Ingredientes { get; set; }
}