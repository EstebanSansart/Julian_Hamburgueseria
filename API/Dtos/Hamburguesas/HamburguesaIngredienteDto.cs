using Dominio.Entities;

namespace API.Dtos;
public class HamburguesaIngredienteDto : HamburguesaDto
{
    public List<Ingrediente> Ingredientes { get; set; }
}