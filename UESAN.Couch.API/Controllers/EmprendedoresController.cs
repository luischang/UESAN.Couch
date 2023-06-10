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
    public class EmprendedoresController : ControllerBase
    {
        private readonly IEmprendadoresServices _emprendedoresServices;
        public EmprendedoresController(IEmprendadoresServices emprendedoresRepository)
        {
            _emprendedoresServices = emprendedoresRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _emprendedoresServices.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _emprendedoresServices.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(EmprendadoresInDTO emprendadoresInUpDTO)
        {
            var result = await _emprendedoresServices.Insert(emprendadoresInUpDTO);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmprendadoresDTO emprendadoresDTO)
        {
            var result = await _emprendedoresServices.Update(emprendadoresDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _emprendedoresServices.Delete(id);
            return Ok(result);
        }

    }
}
