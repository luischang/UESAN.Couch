using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;
using static UESAN.Couch.Core.DTOs.UserAuthRequestDTO;

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
            if (result != null)
            {
                return BadRequest();
                
            }
            return Ok(result);
        }
       
    }
}
