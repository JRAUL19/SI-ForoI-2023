using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_ForoUnidad1.Entities;

namespace WebApi_ForoUnidad1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        private readonly DbContextEcommerce _dbContext;

        public EcommerceController(DbContextEcommerce dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
