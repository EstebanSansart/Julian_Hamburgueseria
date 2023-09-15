using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces.IPagerParam;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public abstract class  GenericRepository<T> where T : BaseEntity{
    private readonly DbAppContext _context;
    private readonly DbSet<T> _entities;

    public GenericRepository(DbAppContext context){
        _context = context;
        _entities = _context.Set<T>();
    }   

    public async virtual Task<T> FindFirst(Expression<Func<T, bool>> expression){
        if (expression is not null){
            return await _entities.Where(expression).FirstAsync();
        }
        return await _entities.FindAsync();
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
        
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
       return await _context.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>()
            .Update(entity);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, IParams param = null){
        if(param is null){
            return await GetAll(expression);
        }
        return await GetAllPaginated(param,expression);

    }
    protected virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null){
        if (expression is not null){
            return await _entities.Where(expression).ToListAsync();
        }
        return await _entities.ToListAsync();
    }

    private async Task<IEnumerable<T>> GetAllPaginated(IParams param, Expression<Func<T, bool>> expression = null ){
        return (await GetAll(expression))
                .Where(x => x.Nombre == param.Search)                
                .Skip((param.PageIndex - 1) * param.PageSize)
                .Take(param.PageSize)
                .ToList();
            
    }

}