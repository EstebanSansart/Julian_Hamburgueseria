namespace Dominio.Entities;
public class Chef : BaseEntity
{
    public string Especialidad { get; set; }
    
    public ICollection<Hamburguesa> Hamburguesas { get; set; }
}