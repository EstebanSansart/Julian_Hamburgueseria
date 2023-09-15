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
    }
}