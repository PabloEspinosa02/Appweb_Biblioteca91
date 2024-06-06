using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosControllers : ControllerBase
    {
        public readonly IUsuarioServices _usuarioServices;

        public UsuariosControllers(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]

        public async Task<IActionResult> ObtenerLista()
        {
            var resuelt = await _usuarioServices.ObtenerUsuarios();
            return Ok(resuelt);
        }

        [HttpGet ("Int:id")]

        public async Task<IActionResult> ObtenerUusuario(int id)
        {
            var result = await _usuarioServices.ObtenerUsuario(id); 

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioResponse request)
        {
            var result = await _usuarioServices.CrearUsuario(request); 

            return Ok(result); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var result = await _usuarioServices.EliminarUsuario(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioResponse request)
        {
            var result = await _usuarioServices.ActualizarUsuario(id, request);
            return Ok(result);
        }
    }
 
}
