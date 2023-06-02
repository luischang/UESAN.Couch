using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _contextAccessor;
        public TiposUsuarioController(ITipoUsuarioRepository contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        [HttpGet]
        public async Task<IEnumerable<TiposUsuario>> GetAll()
        {
            return await _contextAccessor.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposUsuario>> GetById(int id)
        {
            var tipoUsuario = await _contextAccessor.GetById(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            return tipoUsuario;
        }
        [HttpPost]
        public async Task<ActionResult<TiposUsuario>> Create(TiposUsuario tipoUsuario)
        {
            await _contextAccessor.Create(tipoUsuario);
            return CreatedAtAction(nameof(GetById), new { id = tipoUsuario.IdTipo }, tipoUsuario);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TiposUsuario tipoUsuario)
        {
            if (id != tipoUsuario.IdTipo)
            {
                return BadRequest();
            }
            await _contextAccessor.Update(tipoUsuario);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contextAccessor.Delete(id);
            return NoContent();
        }
            
    }
}
