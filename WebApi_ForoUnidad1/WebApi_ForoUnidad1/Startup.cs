using Microsoft.EntityFrameworkCore;
using WebApi_ForoUnidad1.Entities;

namespace WebApi_ForoUnidad1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configuración de Entity Framework y conexión a la base de datos
            services.AddDbContext<DbContextEcommerce>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionE"));
            });

            services.AddDbContext<DbContextValoraciones>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionV"));
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
