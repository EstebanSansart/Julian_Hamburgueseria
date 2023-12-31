using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Hamburguesa> Hamburguesas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<HamburguesaIngrediente> HamburguesasIngredientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}