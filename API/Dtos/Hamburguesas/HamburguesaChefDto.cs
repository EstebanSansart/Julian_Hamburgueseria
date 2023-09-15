using Dominio.Entities;

namespace API.Dtos;
public class HamburguesaChefDto : HamburguesaDto
{
    public ChefDto Chef { get; set; }
}