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
        public EmprendedoresController(IEmprendadoresServices emprendedoresServices)
        {
            _emprendedoresServices = emprendedoresServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emprendedores = await _emprendedoresServices.GetAll();
            return Ok(emprendedores);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emprendedores = await _emprendedoresServices.GetById(id);
            if(id == null)
            {
                return NotFound();
            }
            return Ok(emprendedores);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(EmprendadoresInDTO emprendedoresInUpDTO)
        {
            var result = await _emprendedoresServices.Insert(emprendedoresInUpDTO);
            if (!result)
            {
                return BadRequest();
                
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, EmprendadoresDescDTOS emprendedorDescrDTO)
        {
            if(id != emprendedorDescrDTO.IdEmprendedor)
            {
                return NotFound();
            }
            var result = await _emprendedoresServices.Update(emprendedorDescrDTO);
            if (!result)
            {
                return BadRequest();

                return NoContent();
            }
            return Ok(result);
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _emprendedoresServices.Delete(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
