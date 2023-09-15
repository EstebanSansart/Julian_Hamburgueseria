using Dominio.Entities;

namespace API.Dtos;
public class HamburguesaCategoriaDto : HamburguesaDto
{
    public CategoriaDto Categoria { get; set; }
}