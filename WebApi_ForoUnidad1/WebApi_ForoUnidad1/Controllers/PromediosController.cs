//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApi_ForoUnidad1.Entities;

//namespace WebApi_ForoUnidad1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PromediosController : ControllerBase
//    {
//        private readonly DbContextValoraciones _dbContext;

//        public PromediosController(DbContextValoraciones dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        //TABLA VALORACIONES_PROMEDIOS

//        //Obtener los promedios
//        [HttpGet]
//        public async Task<ActionResult<List<ValoracionPromedio>>> Get()
//        {
//            return await _dbContext.Valoraciones_Promedios.ToListAsync();
//        }

//        //Obtener promedio por id
//        [HttpGet("{producto_id:int}")]
//        public async Task<ActionResult<ValoracionPromedio>> GetById(int producto_id)
//        {
//            var valoracion_Promedio = await _dbContext.Valoraciones_Promedios.FindAsync(producto_id);

//            return await _dbContext.Valoraciones_Promedios.FirstOrDefaultAsync(x => x.ProductoId == producto_id);
//        }

//        //Crear promedio
//        [HttpPost]
//        public async Task<ActionResult> Post(ValoracionPromedio modelo)
//        {
//            _dbContext.Add(modelo);
//            await _dbContext.SaveChangesAsync();

//            return Ok();
//        }


//    }
//}

