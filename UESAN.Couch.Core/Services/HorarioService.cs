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
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;

        public HorarioService(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public async Task<IEnumerable<HorarioDTO>> GetAll()
        {
            var horarios = await _horarioRepository.GetAll();
            var horariosDTO = new List<HorarioDTO>();
            foreach (var horario in horarios)
            {
                var horarioDTO = new HorarioDTO();
                horarioDTO.IdHorario = horario.IdHorario;
                horarioDTO.HoraInicio = horario.HoraInicio;
                horarioDTO.HoraFin = horario.HoraFin;
                horariosDTO.Add(horarioDTO);
            }
            return horariosDTO;
        }

        public async Task<HorarioDTO> GetById(int id)
        {
            var horario = await _horarioRepository.GetById(id);
            if (horario == null)
                return null;

            var horarioDTO = new HorarioDTO()
            {
                IdHorario = horario.IdHorario,
                HoraInicio = horario.HoraInicio,
                HoraFin = horario.HoraFin,
            };
            return horarioDTO;
        }

        public async Task<bool> Insert(HorarioInsertDTO horarioInsertDTO)
        {
            var horario = new Horario();
            horario.HoraInicio = horarioInsertDTO.HoraInicio;
            horario.HoraFin = horarioInsertDTO.HoraFin;

            var result = await _horarioRepository.Insert(horario);
            return result;
        }

        public async Task<bool> Update(HorarioUpdateDTO horarioUpdateDTO)
        {
            var horario = await _horarioRepository.GetById(horarioUpdateDTO.IdHorario);
            if (horario == null)
                return false;

            horario.HoraInicio = horarioUpdateDTO.HoraInicio;
            horario.HoraFin = horarioUpdateDTO.HoraFin;

            var result = await _horarioRepository.Update(horario);
            return result;
        }
    }
}
