using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IChefRepository : IGenericRepository<Chef>
    {
        Task<Chef> GetByUsernameAsync(string username);
    }
}