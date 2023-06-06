using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachesService _service;

        public CoachController(ICoachesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coach = await _service.GetAll();
            return Ok(coach);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coach = await _service.GetById(id);
            if (coach == null)
                return NotFound();
            return Ok(coach);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CoachesInsertDTO insertDTO)
        {
            var result = await _service.Insert(insertDTO);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CoachesUpdateDTO updateDTO)
        {
            if (GetById(id) == null)
                return NotFound(id);

            var result = await _service.Update(updateDTO);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
