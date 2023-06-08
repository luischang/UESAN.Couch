using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPlanController : ControllerBase
    { 
        private readonly ITipoPlanService _service;

        public TipoPlanController(ITipoPlanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tipoplan = await _service.GetAll();
            return Ok(tipoplan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoplan = await _service.GetById(id);
            if (tipoplan == null) 
                return NotFound();
            return Ok(tipoplan);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TipoPlanInsertDTO tipoPlanInsert)
        {
            var result = await _service.Insert(tipoPlanInsert);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoPlanUpdateDTO tipoPlan)
        {
            if(GetById(id) == null)
                return NotFound(id);

            var result = await _service.Update(tipoPlan);
            if(!result)
                return BadRequest();

            return NoContent();
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, TipoPlanUpdateDTO tipoPlan)
        //{
        //    if (GetById(id) == null)
        //        return NotFound(id);

        //    var result = await _service.Update(id, tipoPlan);
        //    if (!result)
        //        return BadRequest();

        //    return NoContent();
        //}
    }
}
