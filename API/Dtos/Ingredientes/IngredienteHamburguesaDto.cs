using Dominio.Entities;

namespace API.Dtos;
public class IngredienteHamburguesaDto : IngredienteDto
{
    public List<Hamburguesa> Hamburguesas { get; set; }
}