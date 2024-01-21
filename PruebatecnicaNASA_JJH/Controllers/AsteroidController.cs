using Microsoft.AspNetCore.Mvc;
using PruebatecnicaNASA_JJH.App.Services;

namespace PruebatecnicaNASA_JJH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsteroidController : ControllerBase
    {
        private readonly IAsteroidService _appAsteroidService;

        public AsteroidController(IAsteroidService appServiceAsteroid)
        {
            _appAsteroidService = appServiceAsteroid;
        }


        [HttpGet]
        [Route("asteroids/{days}")]
        public async Task<IActionResult> GetAsteroids(int days)
        {
            // Validar el parámetro days
            if (days < 1 || days > 7)
            {
                return BadRequest("El parámetro 'days' debe estar entre 1 y 7.");
            }

            var result = await _appAsteroidService.GetAsteroidsAsync(days);

            return Ok(result);
        }
    }
}