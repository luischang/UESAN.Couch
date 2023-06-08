using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprendedoresController : ControllerBase
    {
        private readonly IEmprendedoresRepository _emprendedoresRepository;
        public EmprendedoresController(IEmprendedoresRepository emprendedoresRepository)
        {
            _emprendedoresRepository = emprendedoresRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _emprendedoresRepository.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _emprendedoresRepository.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Emprendadores emprendedores)
        {
            var result = await _emprendedoresRepository.Insert(emprendedores);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Emprendadores emprendedores)
        {
            var result = await _emprendedoresRepository.Update(emprendedores);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _emprendedoresRepository.Delete(id);
            return Ok(result);
        }

    }
}
