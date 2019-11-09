using AzureGettingStarted.Model;
using Microsoft.EntityFrameworkCore;

namespace AzureGettingStarted.Repository
{
    public class Context : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public Context(DbContextOptions dbContextOptions): base(dbContextOptions) { }
    }
}
