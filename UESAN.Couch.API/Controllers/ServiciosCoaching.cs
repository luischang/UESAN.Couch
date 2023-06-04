using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosCoachingController : ControllerBase
    {
        
        private readonly IServiciosCoachingService _serviciosCoachingService;

        
        public ServiciosCoachingController(IServiciosCoachingService serviciosCoachingService)
        {
            
            _serviciosCoachingService = serviciosCoachingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _serviciosCoachingService.GetAll();
            return Ok(servicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servicio = await _serviciosCoachingService.GetById(id);
            if (servicio == null)
                return NotFound();

            return Ok(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ServiciosCoachingInsertDTO category)
        {
            var result = await _serviciosCoachingService.Insert(category);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiciosCoachingDescriptionDTO category)
        {
            if (id != category.IdServicio)
                return NotFound();

            var result = await _serviciosCoachingService.Update(category);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            await _serviciosCoachingService.Delete(id);
            return NoContent();

        }
    }
}

