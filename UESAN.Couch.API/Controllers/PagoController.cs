using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;

namespace UESAN.Couch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoRepository _pagoRepository;
        public PagoController(IPagoRepository pagoRepository)
        {
            _pagoRepository = pagoRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetPagos()
        {
            try
            {
                return Ok(await _pagoRepository.GetPagos());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pago>> GetPago(int id)
        {
            try
            {
                var result = await _pagoRepository.GetPago(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Pago>> CreatePago(Pago pago)
        {
            try
            {
                if (pago == null)
                {
                    return BadRequest();
                }
                var createdPago = await _pagoRepository.AddPago(pago);
                return CreatedAtAction(nameof(GetPago), new { id = createdPago.IdPago }, createdPago);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Pago>> UpdatePago(int id, Pago pago)
        {
            try
            {
                if (id != pago.IdPago)
                {
                    return BadRequest();
                }
                var pagoToUpdate = await _pagoRepository.GetPago(id);
                if (pagoToUpdate == null)
                {
                    return NotFound($"Pago with Id = {id} not found");
                }
                return await _pagoRepository.UpdatePago(pago);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pago>> DeletePago(int id)
        {
            try
            {
                var pagoToDelete = await _pagoRepository.GetPago(id);
                if (pagoToDelete == null)
                {
                    return NotFound($"Pago with Id = {id} not found");
                }
                return await _pagoRepository.DeletePago(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
