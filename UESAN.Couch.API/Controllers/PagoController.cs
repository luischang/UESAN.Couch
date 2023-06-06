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
        //va relacionado con la tabla pago y la tabla detalle pago 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pagos = await _pagoRepository.GetAll();
            return Ok(pagos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pago = await _pagoRepository.GetById(id);
            if (pago == null)
            {
                return NotFound();
            }
            return Ok(pago);
        }
        [HttpGet("GetAllByEmprendedor/{idEmprendedor}")]
        public async Task<IActionResult> GetAllByEmprendedor(int idEmprendedor)
        {
            var pagos = await _pagoRepository.GetAllByEmprendedor(idEmprendedor);
            return Ok(pagos);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Pago pago)
        {
            await _pagoRepository.Insert(pago);
            return Ok(pago);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Pago pago)
        {
            await _pagoRepository.Update(pago);
            return Ok(pago);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pagoRepository.Delete(id);
            return Ok(id);
        }

       
        
    }
}
