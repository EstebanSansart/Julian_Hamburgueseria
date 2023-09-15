using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ChefRepository : GenericRepository<Chef>, IChefRepository
{
    private readonly DbAppContext _context;

    public ChefRepository(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public Task<(int totalRegistros, IEnumerable<Chef> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        throw new NotImplementedException();
    }

    public Task<Chef> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }
}