using Dominio.Entities;

namespace API.Dtos;
public class CategoriaHamburguesaDto : CategoriaDto
{
    public List<Hamburguesa> Hamburguesas { get; set; }
}