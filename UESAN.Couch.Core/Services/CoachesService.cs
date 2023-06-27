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
    public class CoachesService : ICoachesService
    {
        private readonly ICoachesRepository _coachesRepository;

        public CoachesService(ICoachesRepository coachesRepository)
        {
            _coachesRepository = coachesRepository;
        }

        public async Task<IEnumerable<CoachesDTO>> GetAll()
        {
            var coaches = await _coachesRepository.GetAll();
            var coachesDTO = coaches.Select(c => new CoachesDTO()
            {
                IdCoach = c.IdCoach,
                IdPersona = c.IdPersona,
                TarifaHora = c.TarifaHora,
                IsActive = c.IsActive,
                IdServicio = c.IdServicio,
            });
            return coachesDTO;

        }

        public async Task<CoachesDTO> GetById(int id)
        {
            var coach = await _coachesRepository.GetById(id);
            if (coach == null)
                return null;

            var coachDTO = new CoachesDTO()
            {
                IdCoach = coach.IdCoach,
                IdPersona = coach.IdPersona,
                TarifaHora = coach.TarifaHora,
                IsActive = coach.IsActive,
                IdServicio = coach.IdServicio,
            };
            return coachDTO;
        }

        public async Task<bool> Insert(CoachesInsertDTO insertDTO)
        {
            var coach = new Coaches();
            coach.IdPersona = insertDTO.IdPersona;
            coach.TarifaHora = insertDTO.TarifaHora;
            coach.IsActive = insertDTO.IsActive;
            coach.IdServicio = insertDTO.IdServicio;

            var result = await _coachesRepository.Insert(coach);
            return result;
        }

        public async Task<bool> Update(CoachesUpdateDTO updateDTO)
        {
            var coach = await _coachesRepository.GetById(updateDTO.IdCoach);
            if (coach == null)
                return false;

            coach.IdPersona = updateDTO.IdPersona;
            coach.TarifaHora = updateDTO.TarifaHora;
            coach.IsActive = updateDTO.IsActive;
            coach.IdServicio = updateDTO.IdServicio;

            var result = await _coachesRepository.Update(coach);
            return result;
        }
    }
}