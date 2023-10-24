using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_ForoUnidad1.Entities;

namespace WebApi_ForoUnidad1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        private readonly DbContextEcommerce _context;
        private readonly DbContextValoraciones _Context1;

        public EcommerceController(DbContextEcommerce dbContext,
            DbContextValoraciones dbContext1)
        {
            _context = dbContext;
            _Context1 = dbContext1;
        }

        //Obtener productos
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await _context.Productos.ToListAsync();
        }

        //Obtener producto por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound("producto no encontrada");
            }

            return await _context.Productos.FirstOrDefaultAsync(x => x.Id == id);
        }

        //Crear Producto
        [HttpPost]
        public async Task<ActionResult> Post(Producto modelo)
        {
            _context.Add(modelo);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //Editar producto
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Producto modelo)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound("producto no encontrada");
            }

            producto.Nombre = modelo.Nombre;
            producto.Precio = modelo.Precio;
            producto.Descripcion = modelo.Descripcion;

            _context.Update(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //Borrar producto
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound("producto no encontrada");
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
