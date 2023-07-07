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
    public class PagoController : ControllerBase
    {
        private readonly IPagoServices _pagoServices;
        public PagoController(IPagoServices pagoRepository)
        {
            _pagoServices = pagoRepository;
        }
        //va relacionado con la tabla pago y la tabla detalle pago 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pagos = await _pagoServices.GetAll();
            return Ok(pagos);
        }
       /* [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pago = await _pagoServices.GetById(id);
            if (pago == null)
            {
                return Ok(pago);
                
            }
            return NotFound();
        }*/
       
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(PagoInDTO pago)
        {
            var result = await _pagoServices.Insert(pago);
            if (result <= 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, PagoUpDTO pagoUpDTO)
        {
            if (id != pagoUpDTO.IdPago)
            {
                return NotFound();
            }
            var resul = await _pagoServices.Update(pagoUpDTO);
            return Ok(resul);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pagoServices.Delete(id);
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(id);
        }

       
        
    }
}
