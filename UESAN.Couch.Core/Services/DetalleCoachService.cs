using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;
using static UESAN.Couch.Core.DTOs.UserAuthRequestDTO;

namespace UESAN.Couch.Core.Services
{
    public class DetalleCoachService : IDetalleCoachService
    {
        private readonly IDetalleCoachServicioRepository _detalleCoachServicioRepository;

        public DetalleCoachService(IDetalleCoachServicioRepository detalleCoachServicioRepository)
        {
            _detalleCoachServicioRepository = detalleCoachServicioRepository;
        }

        public async Task<IEnumerable<DetalleCouchServicioDTO>> GetAll()
        {
            var detcoachservs = await _detalleCoachServicioRepository.GetAll();
            var detcoachservsDTO = new List<DetalleCouchServicioDTO>();

            foreach (var detcoachserv in detcoachservs)
            {
                var detcoachservDTO = new DetalleCouchServicioDTO();
                detcoachservDTO.IdDetCoachServicio = detcoachserv.IdDetCoachServicio;
                detcoachservDTO.IdServicio = detcoachserv.IdServicio;
                detcoachservDTO.IdCoach = detcoachserv.IdCoach;
                detcoachservDTO.Multiplicador = detcoachserv.Multiplicador; 
                detcoachservDTO.IdPlan = detcoachserv.IdPlan;
                
                detcoachservDTO.IsActive = detcoachserv.IsActive;
                detcoachservsDTO.Add(detcoachservDTO);
            }
            return detcoachservsDTO;
        }

        public async Task<DetalleCouchServicioDTOo> GetById(int id)
        {
            var detcoachserv = await _detalleCoachServicioRepository.GetById(id);
            if (detcoachserv == null)
                return null;
            var detcoachservDTO = new DetalleCouchServicioDTOo()
            {
                IdServicio = detcoachserv.IdServicio,
                IdCoach = detcoachserv.IdCoach,
                Multiplicador = detcoachserv.Multiplicador,
                IdPlan = detcoachserv.IdPlan,
                
                IsActive = detcoachserv.IsActive
            };
            return detcoachservDTO;
        }

        public async Task<IEnumerable<DetalleCouchServicioListDTO>> GetAllByServicio(int idServicio)
        {
            var detcoachservs = await _detalleCoachServicioRepository.GetAllByServicio(idServicio);
            if (!detcoachservs.Any())
                return null;

            var detcoachservsDTO = detcoachservs
                .GroupBy(detcoachserv => detcoachserv.IdCoachNavigation.IdPersonaNavigation)
                .Select(group => group.First())
                .Select(detcoachserv => new DetalleCouchServicioListDTO
                {
                    Coaches = new CoachesUsuariosDTO
                    {
                        TarifaHora = detcoachserv.IdCoachNavigation.TarifaHora,
                        Usuarios = new UsuariosDetCoachServiceDTO
                        {
                            Nombre = detcoachserv.IdCoachNavigation.IdPersonaNavigation.Nombre,
                            Apellido = detcoachserv.IdCoachNavigation.IdPersonaNavigation.Apellido
                        }
                    }
                })
                .ToList();

            return detcoachservsDTO;
        }



        public async Task<int> Insert(DetalleCouchServicioInsertDTO detcoachservsDTO)
        {
            var detcoachserv = new DetalleCoachServicio()
            {
                IdCoach = detcoachservsDTO.IdCoach,
                IdServicio = detcoachservsDTO.IdServicio,
                IdPlan = detcoachservsDTO.IdPlan,
                Multiplicador = detcoachservsDTO.Multiplicador,
                IsActive = detcoachservsDTO.IsActive

            };
           return  await _detalleCoachServicioRepository.Insert(detcoachserv);
        }

        public async Task<bool> Update(DetalleCouchServicioDTO detalleCouchServicioDTO)
        {
            var detcoachser = new DetalleCoachServicio()
            {
                IdDetCoachServicio = detalleCouchServicioDTO.IdDetCoachServicio,
                IdCoach = detalleCouchServicioDTO.IdCoach,
                IdServicio = detalleCouchServicioDTO.IdServicio,
                
                IdPlan = detalleCouchServicioDTO.IdPlan,
                Multiplicador = detalleCouchServicioDTO.Multiplicador,
                IsActive = detalleCouchServicioDTO.IsActive
            };
            return await _detalleCoachServicioRepository.Update(detcoachser);
        }

        public async Task<bool> Delete(int id)
        {
            var detcoachserv = await _detalleCoachServicioRepository.GetById(id);
            if (detcoachserv == null)
                return false;
            var result = await _detalleCoachServicioRepository.Delete(id);
            return result;
        }




    }
}
