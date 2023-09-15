using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class CategoriaRepository:GenericRepository<Categoria>,ICategoriaRepository
    {
        private readonly DbAppContext _context;

        public CategoriaRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public Task<(int totalRegistros, IEnumerable<Categoria> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }
    }
}