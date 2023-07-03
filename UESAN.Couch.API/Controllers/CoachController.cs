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
            var result = await _service.GetAll();
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpGet]
        [Route("{idServicio}")]
        public async Task<IActionResult> GetByIdServicio(int idServicio)
        {
            var result = await _service.GetByIdServicio(idServicio);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CoachesDTO insertDTO)
        {
            var result = await _service.Insert(insertDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> Update(CoachesUpdateDTO updateDTO)
        {
            var result = await _service.Update(updateDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();

        }
        [HttpGet]
        [Route("Validate/{email}/{password}")]
        public async Task<IActionResult> Validate(string email, string password)
        {
            var result = await _service.Validate(email, password);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        


        
    }
}
