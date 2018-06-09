using Entities;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Recipe> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

        public virtual void Save()
        {
            SaveChanges();
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
