using Microsoft.EntityFrameworkCore;

namespace WebApi_ForoUnidad1.Entities
{
    public class DbContextValoraciones : DbContext
    {
        public DbContextValoraciones(DbContextOptions<DbContextValoraciones> options) : base(options)
        {
            Console.WriteLine(Database.GetDbConnection().ConnectionString);
        }

        public DbSet<Valoracion> Valoraciones { get; set; }
    }
}
