using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class IngredienteRepository:GenericRepository<Ingrediente>,IIngredienteRepository
    {
        private readonly DbAppContext _context;

    public IngredienteRepository(DbAppContext context) : base(context)
    {
        _context = context;
    }
    }
}