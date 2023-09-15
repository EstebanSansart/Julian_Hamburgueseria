using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class HamburguesaRepository:GenericRepository<Hamburguesa>,IHamburguesaRepository
    {
        private readonly DbAppContext _context;

    public HamburguesaRepository(DbAppContext context) : base(context)
    {
        _context = context;
    }

        public Task<(int totalRegistros, IEnumerable<Hamburguesa> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }
    }
}