using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    CategoriaRepository _categoria;
    ChefRepository _chef;
    HamburguesaRepository _hamburguesa;
    IngredienteRepository _ingrediente;

    private readonly DbAppContext _context;
    public UnitOfWork(DbAppContext context)
    {
        _context = context;
    }
    public ICategoriaRepository Categorias
    {
        get
        {
            if (_categoria is not null)
            {
                return _categoria;
            }
            return _categoria = new CategoriaRepository(_context);
        }
    }
    public IChefRepository Chefs
    {
        get
        {
            if (_chef is not null)
            {
                return _chef;
            }
            return _chef = new ChefRepository(_context);
        }
    }
    public IHamburguesaRepository Hamburguesas
    {
        get
        {
            if (_hamburguesa is not null)
            {
                return _hamburguesa;
            }
            return _hamburguesa = new HamburguesaRepository(_context);
        }
    }
    public IIngredienteRepository Ingredientes
    {
        get
        {
            if (_ingrediente is not null)
            {
                return _ingrediente;
            }
            return _ingrediente = new IngredienteRepository(_context);
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

}
