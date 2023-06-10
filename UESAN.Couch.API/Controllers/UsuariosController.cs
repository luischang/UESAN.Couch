using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Services;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosService;
        public UsuariosController(IUsuariosServices usuariosService)
        {
            _usuariosService = usuariosService;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserAuthRequestDTO usuarioDTO)
        {
            var result = await _usuariosService.Register(usuarioDTO);
            if (!result)
            {
                return BadRequest();              
            }
            return Ok();

        }
        
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserAuthenticationDTO usuarioDTO)
        {
            var result = await _usuariosService.Validate(usuarioDTO.CorreoElectronico, usuarioDTO.Contrasena);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
       
    }
}
