using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ITiposUsuariosRepository _usuariosService;
        public UsuariosController(ITiposUsuariosRepository usuariosService)
        {
            _usuariosService = usuariosService;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(Usuarios user)
        {
            var result = await _usuariosService.SignUp(user);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var result = await _usuariosService.SignIn(email, password);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("IsEmailRegistered")]
        public async Task<IActionResult> IsEmailRegistered(string email)
        {
            var result = await _usuariosService.IsEmailRegistered(email);
            return Ok(result);
        }
    }
}
