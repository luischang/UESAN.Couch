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
    public class TiposUsuariosService : ITiposUsuariosService
    {
        private readonly ITipoUsuarioRepository _tiposUsuariorepository;
        public TiposUsuariosService(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tiposUsuariorepository = tipoUsuarioRepository;
        }
        public async Task<IEnumerable<TiposUsuarioDescriptionDTO>> GetAll()
        {
            var tiposUsuarios = await _tiposUsuariorepository.GetAll();
            var tiposUsuariosDTO = new List<TiposUsuarioDescriptionDTO>();
            foreach (var tipoUsuario in tiposUsuarios)
            {
                var tipoUsuarioDTO = new TiposUsuarioDescriptionDTO();
                tipoUsuarioDTO.IdTipo = tipoUsuario.IdTipo;
                tipoUsuarioDTO.NombreTipo = tipoUsuario.NombreTipo;
                tiposUsuariosDTO.Add(tipoUsuarioDTO);
            }
            return tiposUsuariosDTO;
        }
        public async Task<TiposUsuarioDTOS> GetById(int id)
        {
            var tipoUsuario = await _tiposUsuariorepository.GetById(id);
            var tipoUsuarioDTO = new TiposUsuarioDTOS();
            tipoUsuarioDTO.IdTipo = tipoUsuario.IdTipo;
            tipoUsuarioDTO.NombreTipo = tipoUsuario.NombreTipo;
            tipoUsuarioDTO.IsActive = tipoUsuario.IsActive;
            return tipoUsuarioDTO;
        }
        public async Task<bool> Insert(TiposUsuarioInsertDTO tipoUsuarioInsertDTO)
        {
            var tipoUsuario = new TiposUsuario();
            tipoUsuario.NombreTipo = tipoUsuarioInsertDTO.NombreTipo;
            tipoUsuario.IsActive = tipoUsuarioInsertDTO.IsActive;
            var result = await _tiposUsuariorepository.Insert(tipoUsuario);
            return result;
        }
        public async Task<bool> Update(TiposUsuarioDTOS tipoUsuarioDTO)
        {
            var tipoUsuario = await _tiposUsuariorepository.GetById(tipoUsuarioDTO.IdTipo);
            if (tipoUsuario == null)
                return false;
            tipoUsuario.NombreTipo = tipoUsuarioDTO.NombreTipo;
            tipoUsuario.IsActive = tipoUsuarioDTO.IsActive;
            var result = await _tiposUsuariorepository.Update(tipoUsuario);
            return result;
        }
        public async Task<bool> Delete(int id)
        {
            var tipoUsuario = await _tiposUsuariorepository.GetById(id);
            if (tipoUsuario == null)
                return false;
            var result = await _tiposUsuariorepository.Delete(id);
            return result;
        }



    }
}
