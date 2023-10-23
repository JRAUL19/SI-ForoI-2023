using Microsoft.EntityFrameworkCore;

namespace WebApi_ForoUnidad1.Entities
{
    public class DbContextEcommerce : DbContext
    {
        public DbContextEcommerce(DbContextOptions<DbContextEcommerce> options) : base(options)
        {
            Console.WriteLine(Database.GetDbConnection().ConnectionString);
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
