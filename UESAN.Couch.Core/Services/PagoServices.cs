using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;

namespace UESAN.Couch.Core.Services
{
    public class PagoServices : IPagoServices
    {
        private readonly IPagoRepository _pagoRepository;
        public PagoServices(IPagoRepository pagoRepository)
        {
            _pagoRepository = pagoRepository;
        }
        //va relacionado con la tabla pago y la tabla detalle pago 
        public async Task<IEnumerable<PagoEmprendedorDTO>> GetAll()
        {
            var pagos = await _pagoRepository.GetAll();

            var pagoDTO = pagos.Select(p => new PagoEmprendedorDTO
            {
                IdPago = p.IdPago,
                FechaRegistro = p.FechaRegistro,
                IdEmprendedorNavigation = new EmprendadoresDescDTOS()
                {
                    IdEmprendedor = p.IdEmprendedorNavigation.IdEmprendedor,
                    IdPersona = p.IdEmprendedorNavigation.IdPersona,
                },
                TotalPago = p.TotalPago



            });
            return pagoDTO;


        }
        public async Task<PagoEmprendedorDTO> GetById(int id)
        {
            var pago = await _pagoRepository.GetById(id);
            if (pago == null)
                return null;
            

            var pagoDTO = new PagoEmprendedorDTO()
            {
                IdPago = pago.IdPago,
                FechaRegistro = pago.FechaRegistro,
                IdEmprendedorNavigation = new EmprendadoresDescDTOS()
                {
                    IdEmprendedor = pago.IdEmprendedorNavigation.IdEmprendedor,
                    IdPersona = pago.IdEmprendedorNavigation.IdPersona,
                },
                TotalPago = pago.TotalPago
                
            };
            return pagoDTO;
        }


        public async Task<bool> Insert(PagoInDTO pagoInUpDTO)
        {
            var pago = new Pago()
            {
                FechaRegistro = pagoInUpDTO.FechaRegistro,
                IdEmprendedor = pagoInUpDTO.IdEmprendedor,
                TotalPago = pagoInUpDTO.TotalPago,
                IsActive = true
            };
            return await _pagoRepository.Insert(pago);


        }
        public async Task<bool> Update(PagoUpDTO pagoInUpDTO)
        {
            var pago = new Pago()
            {
                IdPago = pagoInUpDTO.IdPago,
                FechaRegistro = pagoInUpDTO.FechaRegistro,
                IdEmprendedor = pagoInUpDTO.IdEmprendedor,
                TotalPago = pagoInUpDTO.TotalPago,
                IsActive = true
            };
            return await _pagoRepository.Update(pago);

        }
        public async Task<bool> Delete(int id)
        {
            return await _pagoRepository.Delete(id);

        }

    }
}
