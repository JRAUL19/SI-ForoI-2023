using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
