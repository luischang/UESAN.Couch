using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePagoController : ControllerBase
    {
        private readonly IDetallePagoService _detallePagoService;

        public DetallePagoController(IDetallePagoService detallePagoService)
        {
            _detallePagoService = detallePagoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detallePagos = await _detallePagoService.GetAll();
            return Ok(detallePagos);
        }


        [HttpGet("{idServicio}")]
        public async Task<IActionResult> GetAllByPago(int idPago)
        {
            var detallePagos = await _detallePagoService.GetAllByPago(idPago);
            if (detallePagos == null)
                return NotFound();

            return Ok(detallePagos);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(DetallePagoInsertDTO insertDTO)
        {
            var result = await _detallePagoService.Insert(insertDTO);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DetallePagoUpdateDTO detallePagoUpdateDTO)
        {
            if (id != detallePagoUpdateDTO.IdDetpago)
                return NotFound();

            var result = await _detallePagoService.Update(detallePagoUpdateDTO);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}

