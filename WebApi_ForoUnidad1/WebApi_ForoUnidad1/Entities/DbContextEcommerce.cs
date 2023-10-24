using Microsoft.EntityFrameworkCore;

namespace WebApi_ForoUnidad1.Entities
{
    public class DbContextEcommerce : DbContext
    {
        public DbContextEcommerce(DbContextOptions<DbContextEcommerce> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
