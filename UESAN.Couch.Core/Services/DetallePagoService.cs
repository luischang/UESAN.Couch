using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Services
{
    public class DetallePagoService : IDetallePagoService
    {
        private readonly IDetallePagoRepository _detallePagoRepository;

        public DetallePagoService(IDetallePagoRepository detallePagoRepository)
        {
            _detallePagoRepository = detallePagoRepository;
        }

        public async Task<IEnumerable<DetallePagoDTO>> GetAll()
        {
            var detpagos = await _detallePagoRepository.GetAll();
            var detpagosDTO = new List<DetallePagoDTO>();

            foreach (var detalle in detpagos)
            {
                var detpagoDTO = new DetallePagoDTO();
                detpagoDTO.IdDetpago = detalle.IdDetpago;
                detpagoDTO.IdPago = detalle.IdPago;
                detpagoDTO.IdDetCoachServicio = detalle.IdDetCoachServicio;
                detpagoDTO.NroSolicitudes = detalle.NroSolicitudes;

                detpagosDTO.Add(detpagoDTO);
            }
            return detpagosDTO;
        }

        public async Task<DetallePagoDTO> GetById(int id)
        {
            var detPago = await _detallePagoRepository.GetById(id);
            if (detPago == null)
                return null;

            var detPagoDTO = new DetallePagoDTO()
            {
                IdDetpago = detPago.IdDetpago,
                IdPago = detPago.IdPago,
                IdDetCoachServicio = detPago.IdDetCoachServicio,
                NroSolicitudes = detPago.NroSolicitudes,
            };

            return detPagoDTO;
        }

        public async Task<bool> Insert(DetallePagoInsertDTO detallePagoInsertDTO)
        {
            var detPago = new DetallePago();
            detPago.IdPago = detallePagoInsertDTO.IdPago;
            detPago.IdDetCoachServicio = detallePagoInsertDTO.IdDetCoachServicio;
            detPago.NroSolicitudes = detallePagoInsertDTO.NroSolicitudes;

            var result = await _detallePagoRepository.Insert(detPago);
            return result;
        }

        public async Task<bool> Update(DetallePagoUpdateDTO updateDTO)
        {
            var detPago = await _detallePagoRepository.GetById(updateDTO.IdDetpago);
            if (detPago == null)
                return false;

            detPago.IdDetpago = updateDTO.IdDetpago;
            detPago.IdPago = updateDTO.IdPago;
            detPago.IdDetCoachServicio = updateDTO.IdDetCoachServicio;
            detPago.NroSolicitudes = updateDTO.NroSolicitudes;

            var result = await _detallePagoRepository.Update(detPago);
            return result;
        }

        public async Task<IEnumerable<DetallePagoListDTO>> GetAllByPago(int idPago)
        {
            var detPagos = await _detallePagoRepository.GetAllByPago(idPago);
            if (!detPagos.Any())
                return null;

            var detPagosDTO = detPagos.Select(detPago => new DetallePagoListDTO
            {
                PagoDTO = new PagoDTO
                {
                    IdEmprendedor = detPago.IdPagoNavigation.IdEmprendedor,
                }
            }).ToList();
            return detPagosDTO;
        }

        public async Task<IEnumerable<DetallePagoListDTO>> GetAllByDetCoachServ(int idDetCoachServ)
        {
            return null;
        }
    }
}
