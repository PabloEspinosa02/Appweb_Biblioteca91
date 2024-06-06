using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresService _autorService;
        public AutoresController(IAutoresService autorService)
        {
            _autorService = autorService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            var result = await _autorService.GetAutores();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] Autor request)
        {
            var result = await _autorService.Crear(request);
            return Ok(result);

        }

        [HttpPut("id")]
        public async Task<IActionResult> Editar([FromBody] Autor request, int PkAutor)
        {
            var result = await _autorService.Editar(request, PkAutor);
            return Ok(result);

        }

        [HttpDelete("id")]
        public async Task<IActionResult> Eliminar(int PkAutor)
        {
            var result = await _autorService.Eliminar(PkAutor);
            return Ok(result);

        }



    }
}
