using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_ForoUnidad1.Entities;

namespace WebApi_ForoUnidad1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoracionesController : ControllerBase
    {
        private readonly DbContextValoraciones _dbContext;
        private readonly DbContextEcommerce _Context;

        public ValoracionesController(DbContextValoraciones dbContext,
            DbContextEcommerce dbContext1)
        {
            _dbContext = dbContext;
            _Context = dbContext1;
        }

        //Obtener valoraciones
        [HttpGet]
        public async Task<ActionResult<List<Valoracion>>> GetAll()
        {
            return await _dbContext.Valoraciones.ToListAsync();
        }

        //Obtener valoraciones por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Valoracion>> GetById(int id)
        {
            var valoracion = await _dbContext.Valoraciones.FindAsync(id);

            if (valoracion == null)
            {
                return NotFound("La valoracion no fue encontrada");
            }

            return await _dbContext.Valoraciones.FirstOrDefaultAsync(x => x.Id == id);
        }

        //Crear valoracion
        [HttpPost]
        public async Task<ActionResult> Post(Valoracion modelo)
        {
            _dbContext.Add(modelo);
            await _dbContext.SaveChangesAsync();

            // Recupera el producto correspondiente
            var producto = await _Context.Productos.FindAsync(modelo.ProductoId);

            if (producto != null)
            {
                // Recalcula el promedio
                var valoraciones = await _dbContext.Valoraciones
                    .Where(v => v.ProductoId == modelo.ProductoId)
                    .Select(v => v.Puntuacion)
                    .ToListAsync();

                if (valoraciones.Any())
                {
                    producto.Valoracion = valoraciones.Average();
                    await _Context.SaveChangesAsync();
                }
            }

            return Ok();
        }

        //Editar una valoracion
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Valoracion modelo)
        {
            var valoracion = await _dbContext.Valoraciones.FindAsync(id);

            if (valoracion == null)
            {
                return NotFound("La valoración no fue encontrada");
            }

            valoracion.ProductoId = modelo.ProductoId;
            valoracion.Puntuacion = modelo.Puntuacion;
            valoracion.Comentario = modelo.Comentario;

            _dbContext.Update(valoracion);
            await _dbContext.SaveChangesAsync();

            // Recalcula el promedio de las valoraciones para el producto
            await RecalcularPromedioProducto(modelo.ProductoId);

            return Ok();
        }


        //Eliminar valoracion
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var valoracion = await _dbContext.Valoraciones.FindAsync(id);

            if (valoracion == null)
            {
                return NotFound("La valoración no fue encontrada");
            }

            _dbContext.Valoraciones.Remove(valoracion);
            await _dbContext.SaveChangesAsync();

            // Recalcula el promedio de las valoraciones para el producto
            await RecalcularPromedioProducto(valoracion.ProductoId);

            return Ok();
        }

        private async Task RecalcularPromedioProducto(int productoId)
        {
            var valoraciones = await _dbContext.Valoraciones
                .Where(v => v.ProductoId == productoId)
                .Select(v => v.Puntuacion)
                .ToListAsync();

            var producto = await _Context.Productos.FindAsync(productoId);

            if (producto != null)
            {
                if (valoraciones.Any())
                {
                    producto.Valoracion = valoraciones.Average();
                }
                else
                {
                    producto.Valoracion = 0; // No hay valoraciones, promedio a cero
                }

                await _Context.SaveChangesAsync();
            }
        }

    }
}
