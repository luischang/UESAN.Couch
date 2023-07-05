using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCouchServicioController : ControllerBase
    {
        private readonly IDetalleCoachService _detalleCoachService;


        public DetalleCouchServicioController(IDetalleCoachService detalleCoachService)
        {

            _detalleCoachService = detalleCoachService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var detaCoachServi = await _detalleCoachService.GetAll();
            return Ok(detaCoachServi);
        }


        [HttpGet("GetAllByServicio{idServicio}")]
        public async Task<IActionResult> GetAllByServicio(int idServicio)
        {
            var detaCoachServis = await _detalleCoachService.GetAllByServicio(idServicio);
            if (detaCoachServis == null)
                return NotFound();

            return Ok(detaCoachServis);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(DetalleCouchServicioInsertDTO detaCoachServi)
        {
            var result = await _detalleCoachService.Insert(detaCoachServi);
            if (result<=0)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id, DetalleCouchServicioDTO detaCoachServi)
        {
            if (id != detaCoachServi.IdDetCoachServicio)
                return NotFound();

            var result = await _detalleCoachService.Update(detaCoachServi);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _detalleCoachService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();

        }
    }
}
