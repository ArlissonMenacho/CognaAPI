using CognaAPI.Domain.Entidades;
using CognaAPI.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CognaAPI.Infra.Context
{
    public class CognaDbContext : DbContext
    {
        public CognaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        #region OverridesContexto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SeedToDo
            modelBuilder.Entity<Todo>().HasData(new Todo(Guid.Parse("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"), "Comprar Utensílios de cozinha", DateTime.Now.AddDays(2)));
            modelBuilder.Entity<Todo>().HasData(new Todo(Guid.Parse("03e68c0c-1164-43c9-6bb9-08d9e34472ad"), "Fazer Macarronada", DateTime.Now.AddDays(1)));
            modelBuilder.Entity<Todo>().HasData(new Todo(Guid.Parse("69881eb1-b47e-4d56-6bc1-08d9e34472ad"), "Buscar encomenda", DateTime.Now.AddDays(5)));
            #endregion

            modelBuilder.ApplyConfiguration(new TodoMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Criado = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UltimaModificacao = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
