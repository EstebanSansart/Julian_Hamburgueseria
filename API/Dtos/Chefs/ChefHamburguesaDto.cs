using Dominio.Entities;

namespace API.Dtos;
public class ChefHamburguesaDto : ChefDto
{
    public List<HamburguesaDto> Hamburguesas { get; set; }
}