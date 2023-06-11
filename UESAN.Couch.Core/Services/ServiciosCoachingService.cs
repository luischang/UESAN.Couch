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
    public class ServiciosCoachingService : IServiciosCoachingService
    {
        private readonly IServiciosCoachingRepository _serviciosCoachingRepository;

        public ServiciosCoachingService(IServiciosCoachingRepository serviciosCoachingRepository)
        {
            _serviciosCoachingRepository = serviciosCoachingRepository;
        }

        public async Task<IEnumerable<ServiciosCoachingDescriptionDTOo>> GetAll()
        {
            var servicios = await _serviciosCoachingRepository.GetAll();
            var serviciosDTO = new List<ServiciosCoachingDescriptionDTOo>();

            foreach (var servicio in servicios)
            {
                var servicioDTO = new ServiciosCoachingDescriptionDTOo();
                servicioDTO.IdServicio = servicio.IdServicio;
                servicioDTO.NombreServicio = servicio.NombreServicio;
                serviciosDTO.Add(servicioDTO);
            }
            return serviciosDTO;
        }
        public async Task<ServiciosCoachingGetAllDTO> GetById(int id)
        {
            var servicio = await _serviciosCoachingRepository.GetById(id);
            var servicioDTO = new ServiciosCoachingGetAllDTO();
            servicioDTO.IdServicio = servicio.IdServicio;
            servicioDTO.NombreServicio = servicio.NombreServicio;

            return servicioDTO;
        }

        public async Task<bool> Insert(ServiciosCoachingInsertDTO serviciosCoachingInsertDTO)
        {
            var servicio = new ServiciosCoaching();
            servicio.NombreServicio = serviciosCoachingInsertDTO.NombreServicio;
            servicio.IsActive = serviciosCoachingInsertDTO.IsActive;
            var result = await _serviciosCoachingRepository.Insert(servicio);
            return result;
        }

        public async Task<bool> Update(ServiciosCoachingDescriptionDTO serviciosCoachingDescriptionDTO)
        {
            var servicio = await _serviciosCoachingRepository.GetById(serviciosCoachingDescriptionDTO.IdServicio);
            if (servicio == null)
                return false;
            servicio.NombreServicio = serviciosCoachingDescriptionDTO.NombreServicio;
            servicio.IsActive = serviciosCoachingDescriptionDTO.IsActive;
            var result = await _serviciosCoachingRepository.Update(servicio);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var servicio = await _serviciosCoachingRepository.GetById(id);
            if (servicio == null)
                return false;

            var result = await _serviciosCoachingRepository.Delete(id);
            return result;
        }


    }
}
