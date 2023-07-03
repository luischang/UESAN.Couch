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
        private readonly IJWTFactory _jwtFactory;

        public CoachesService(ICoachesRepository coachesRepository, IJWTFactory jWTFactory)
        {
            _coachesRepository = coachesRepository;
            _jwtFactory = jWTFactory;
        }
        public async Task<UserAuthResponseDTO> Validate(string email, string password)
        {
            var user = await _coachesRepository.SignIn(email, password);
            if (user == null)
                return null;

            var token = _jwtFactory.GenerateJWToken(user);

            var UsuariosDTO = new UserAuthResponseDTO()
            {
                IdPersona = user.IdPersona,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                CorreoElectronico = user.CorreoElectronico,
                Token = token
            };
            return UsuariosDTO;
        }

        public async Task<IEnumerable<CoachesDecripDTO>> GetAll()
        {
            var coaches = await _coachesRepository.GetAll();
            var coachesDTO = coaches.Select(c => new CoachesDecripDTO
            {
                IdCoach = c.IdCoach,
                IdPersonaNavigation = new UserAuthRequestDTO()
                {
                    Nombre = c.IdPersonaNavigation.Nombre,
                    Apellido = c.IdPersonaNavigation.Apellido,
                    Genero = c.IdPersonaNavigation.Genero,
                    NroContacto = c.IdPersonaNavigation.NroContacto,
                    CorreoElectronico = c.IdPersonaNavigation.CorreoElectronico,
                    Contrasena = c.IdPersonaNavigation.Contrasena,
                    IsActive = true,
                    IdTipoNavegation = c.IdPersonaNavigation.IdTipoNavegation

                },
                TarifaHora = c.TarifaHora,
                IsActive = true,
                IdServicio = c.IdServicio,
            });
            return coachesDTO;

        }

        public async Task<CoachesServiceDTO> GetByIdServicio(int idServicio)
        {
            var coach = await _coachesRepository.GetByIdServicio(idServicio);
            if (coach == null)
                return null;

            var coachDTO = new CoachesServiceDTO()
            {
                IdCoach = coach.IdCoach,
                IdServicioNavigation = new ServiciosCoachingInsertDTO()
                {
                    NombreServicio = coach.IdServicioNavigation.NombreServicio,
                    IsActive = coach.IdServicioNavigation.IsActive,
                },
                IdPersonaNavigation = new UsuariosCoachesServiceDTO()
                {
                    Nombre = coach.IdPersonaNavigation.Nombre,
                    Apellido = coach.IdPersonaNavigation.Apellido,
                    Genero = coach.IdPersonaNavigation.Genero,
                    NroContacto = coach.IdPersonaNavigation.NroContacto,
                    CorreoElectronico = coach.IdPersonaNavigation.CorreoElectronico

                },
                TarifaHora = coach.TarifaHora
            };
            return coachDTO;
        }
        public async Task<CoachesDecripDTO> GetById(int id)
        {
            var coach = await _coachesRepository.GetById(id);
            if (coach == null)
                return null;

            var coachDTO = new CoachesDecripDTO()
            {
                IdCoach = coach.IdCoach,
                IdPersonaNavigation = new UserAuthRequestDTO()
                {
                    Nombre = coach.IdPersonaNavigation.Nombre,
                    Apellido = coach.IdPersonaNavigation.Apellido,
                    Genero = coach.IdPersonaNavigation.Genero,
                    NroContacto = coach.IdPersonaNavigation.NroContacto,
                    CorreoElectronico = coach.IdPersonaNavigation.CorreoElectronico,
                    Contrasena = coach.IdPersonaNavigation.Contrasena,
                    IsActive = true,
                    IdTipoNavegation = coach.IdPersonaNavigation.IdTipoNavegation

                },
                TarifaHora = coach.TarifaHora,
                IsActive = coach.IsActive,
                IdServicio = coach.IdServicio,
            };
            return coachDTO;
        }
        public async Task<bool> Insert(CoachesDTO insertDTO)
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
        public async Task<bool> Delete(int id)
        {
            var coach = await _coachesRepository.GetById(id);
            if (coach == null)
                return false;

            var result = await _coachesRepository.Delete(id);
            return result;
        }
    }
}