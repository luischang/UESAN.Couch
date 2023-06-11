using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;
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
                detcoachservDTO.IdHorario = detcoachserv.IdHorario;

                detcoachservsDTO.Add(detcoachservDTO);
            }
            return detcoachservsDTO;
        }

        public async Task<DetalleCouchServicioDTO> GetById(int id)
        {
            var detcoachserv = await _detalleCoachServicioRepository.GetById(id);
            if (detcoachserv == null)
                return null;
            var detcoachservDTO = new DetalleCouchServicioDTO()
            {
                IdServicio = detcoachserv.IdServicio,
                IdCoach = detcoachserv.IdCoach,
                Multiplicador = detcoachserv.Multiplicador,
                IdPlan = detcoachserv.IdPlan,
                IdHorario = detcoachserv.IdHorario
            };
            return detcoachservDTO;
        }

        public async Task<IEnumerable<DetalleCouchServicioListDTO>> GetAllByServicio(int idServicio)
        {
            var detcoachservs = await _detalleCoachServicioRepository.GetAllByServicio(idServicio);
            if (!detcoachservs.Any())
                return null;
            var detcoachservsDTO = detcoachservs.Select(detcoachserv => new DetalleCouchServicioListDTO
            {
                Coaches = new CoachesUsuariosDTO
                {
                    TarifaHora = detcoachserv.IdCoachNavigation.TarifaHora ,
                    //modifique esto james UsuariosDTO(UsuariosDTO.TipoUsuario.Coach)
                    Usuarios = new UserAuthRequestDTO
                    {
                        Nombre = detcoachserv.IdCoachNavigation.IdPersonaNavigation.Nombre,
                        Apellido = detcoachserv.IdCoachNavigation.IdPersonaNavigation.Apellido
                    }
                }
            }).ToList();

            return detcoachservsDTO;
        }



        public async Task<bool> Insert(DetalleCouchServicioInsertDTO detcoachservsDTO)
        {
            var detcoachserv = new DetalleCoachServicio()
            {
                IdCoach = detcoachservsDTO.IdCoach,
                IdHorario = detcoachservsDTO.IdHorario,
                IdServicio = detcoachservsDTO.IdServicio,
                IdPlan = detcoachservsDTO.IdPlan,
                Multiplicador = detcoachservsDTO.Multiplicador,

            };

            return await _detalleCoachServicioRepository.Insert(detcoachserv);
        }

        public async Task<bool> Update(DetalleCouchServicioDTO detalleCouchServicioDTO)
        {
            var detcoachserv = await _detalleCoachServicioRepository.GetById(detalleCouchServicioDTO.IdDetCoachServicio);
            if (detcoachserv == null)
                return false;
            detcoachserv.IdPlan = detalleCouchServicioDTO.IdPlan;
            detcoachserv.IdCoach = detalleCouchServicioDTO.IdCoach;
            detcoachserv.IdHorario = detalleCouchServicioDTO.IdHorario;
            detcoachserv.IdServicio = detalleCouchServicioDTO.Multiplicador;
            detcoachserv.Multiplicador = detalleCouchServicioDTO.IdPlan;

            var result = await _detalleCoachServicioRepository.Update(detcoachserv);
            return result;
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
