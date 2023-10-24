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

        public ValoracionesController(DbContextValoraciones dbContext)
        {
            _dbContext = dbContext;
        }

        //TABLA VALORACIONES
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

        //Crear nueva valoracion
        [HttpPost]
        public async Task<ActionResult> Post(Valoracion modelo)
        {
            _dbContext.Add(modelo);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        //Editar una valoracion
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Valoracion modelo)
        {
            var valoracion = await _dbContext.Valoraciones.FindAsync(id);

            if (valoracion == null)
            {
                return NotFound("La valoracion no fue encontrada");
            }

            valoracion.ProductoId = modelo.ProductoId;
            valoracion.Puntuacion = modelo.Puntuacion;
            valoracion.Comentario = modelo.Comentario;

            _dbContext.Update(valoracion);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        //Eliminar valoracion
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var valoracion = await _dbContext.Valoraciones.FindAsync(id);

            if (valoracion == null)
            {
                return NotFound("La valoracion no fue encontrada");
            }

            _dbContext.Valoraciones.Remove(valoracion);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
