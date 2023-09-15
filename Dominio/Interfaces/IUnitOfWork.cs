namespace Dominio.Interfaces;

    public interface IUnitOfWork
    {
        ICategoriaRepository Categorias {get;}
        IChefRepository Chefs {get;}
        IHamburguesaRepository Hamburguesas {get;}
        IIngredienteRepository Ingredientes {get;}
        Task<int> SaveAsync();
    }

