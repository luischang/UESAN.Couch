using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly IHorarioService _service;

        public HorarioController(IHorarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var horario = await _service.GetAll();
            return Ok(horario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var horario = await _service.GetById(id);
            if (horario == null)
                return NotFound();
            return Ok(horario);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(HorarioInsertDTO horarioInsert)
        {
            var result = await _service.Insert(horarioInsert);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HorarioUpdateDTO horarioUpdate)
        {
            if (GetById(id) == null)
                return NotFound(id);

            var result = await _service.Update(horarioUpdate);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
