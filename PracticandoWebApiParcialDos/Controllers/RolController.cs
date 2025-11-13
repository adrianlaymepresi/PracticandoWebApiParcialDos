using Microsoft.AspNetCore.Mvc;
using PracticandoWebApiParcialDos.Models.DTOs;
using PracticandoWebApiParcialDos.Services;

namespace PracticandoWebApiParcialDos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly RolService _service;

        public RolController(RolService service)
        {
            _service = service;
        }

        [HttpGet("obtener")]
        public async Task<IActionResult> Obtener()
        {
            try
            {
                var roles = await _service.ObtenerTodosAsync();
                return Ok(roles);
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
                var dto = new RolIdDto { Id = id };
                var rol = await _service.ObtenerPorIdAsync(dto);
                return Ok(rol);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RolRegistrarDto dto)
        {
            try
            {
                var rol = await _service.RegistrarAsync(dto);
                return Ok(new { mensaje = "Rol registrado", rol });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar(RolActualizarDto dto)
        {
            try
            {
                var rol = await _service.ActualizarAsync(dto);
                return Ok(new { mensaje = "Rol actualizado", rol });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("borrarLogico")]
        public async Task<IActionResult> BorrarLogico(RolIdDto dto)
        {
            try
            {
                var rol = await _service.BorradoLogicoAsync(dto);
                return Ok(new { mensaje = "Rol desactivado", rol });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("borrarFisico")]
        public async Task<IActionResult> BorrarFisico(RolIdDto dto)
        {
            try
            {
                var rol = await _service.BorradoFisicoAsync(dto);
                return Ok(new { mensaje = "Rol eliminado permanentemente", rol });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}

/*

POR SI ACASO NECESITAS LA VERSION ANTERIOR CON UN SOLO DTO

        [HttpPost("obtenerPorId")]
        public async Task<IActionResult> ObtenerPorId(RolIdDto dto)
        {
            try
            {
                var rol = await _service.ObtenerPorIdAsync(dto);
                return Ok(rol);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        } 

*/