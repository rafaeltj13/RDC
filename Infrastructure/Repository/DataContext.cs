using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
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
