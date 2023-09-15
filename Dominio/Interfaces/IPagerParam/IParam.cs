namespace Dominio.Interfaces.IPagerParam;
public interface IParams{
    int PageSize {get; set;}
    int PageIndex {get; set;}
    string Search {get; set;}
}