using Microsoft.AspNetCore.Mvc;
using PracticandoWebApiParcialDos.Models.DTOs;
using PracticandoWebApiParcialDos.Services;

namespace PracticandoWebApiParcialDos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet("obtener")]
        public async Task<IActionResult> Obtener()
        {
            try
            {
                var usuarios = await _service.ObtenerTodosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("obtenerPorId/{id}")]
        public async Task<IActionResult> ObtenerPorIdGet(int id)
        {
            try
            {
                var dto = new UsuarioIdDto { Id = id };
                var usuario = await _service.ObtenerPorIdAsync(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("obtenerPorId")]
        public async Task<IActionResult> ObtenerPorId(UsuarioIdDto dto)
        {
            try
            {
                var usuario = await _service.ObtenerPorIdAsync(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioRegistrarDto dto)
        {
            try
            {
                var usuario = await _service.RegistrarAsync(dto);
                return Ok(new { mensaje = "Usuario registrado", usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar(UsuarioActualizarDto dto)
        {
            try
            {
                var usuario = await _service.ActualizarAsync(dto);
                return Ok(new { mensaje = "Usuario actualizado", usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("borrarLogico")]
        public async Task<IActionResult> BorrarLogico(UsuarioIdDto dto)
        {
            try
            {
                var usuario = await _service.BorradoLogicoAsync(dto);
                return Ok(new { mensaje = "Usuario desactivado", usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("borrarFisico")]
        public async Task<IActionResult> BorrarFisico(UsuarioIdDto dto)
        {
            try
            {
                var usuario = await _service.BorradoFisicoAsync(dto);
                return Ok(new { mensaje = "Usuario eliminado permanentemente", usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
