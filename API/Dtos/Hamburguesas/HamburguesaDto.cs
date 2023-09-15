using Dominio.Entities;

namespace API.Dtos;
public class HamburguesaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Precio { get; set; }
}