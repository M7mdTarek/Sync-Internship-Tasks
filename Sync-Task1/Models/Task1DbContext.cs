using Microsoft.EntityFrameworkCore;


namespace Sync_Task1.Models
{
    public class Task1DbContext:DbContext
    {
        public Task1DbContext(DbContextOptions<Task1DbContext> options):base(options)
        {
            
        }

        public DbSet<Bug> bug { get; set; }

        public DbSet<Developer> developer { get; set; }

        public DbSet<Solution> solution { get; set; }

    }
}
