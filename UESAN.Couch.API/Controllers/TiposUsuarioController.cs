using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    { 
    private readonly ITiposUsuariosService _tiposUsuarioService;
        public TiposUsuarioController(ITiposUsuariosService tiposUsuarioRepository)
        {
            _tiposUsuarioService = tiposUsuarioRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tiposUsuario = await _tiposUsuarioService.GetAll();
            return Ok(tiposUsuario);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoUsuario = await _tiposUsuarioService.GetById(id);
            if (tipoUsuario == null)
                return NotFound();
            return Ok(tipoUsuario);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(TiposUsuarioInsertDTO tipoUsuario)
        {
            var result = await _tiposUsuarioService.Insert(tipoUsuario);
            if (!result)
                return BadRequest();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TiposUsuarioDTOS tipoUsuario)
        {
            if (id != tipoUsuario.IdTipo)
                return NotFound();
            var result = await _tiposUsuarioService.Update(tipoUsuario);
            if (!result)
                return BadRequest();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tiposUsuarioService.Delete(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }

    }
          
}