using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;
using UESAN.Shopping.Core.Interfaces;
using static UESAN.Couch.Core.DTOs.UsuariosDTO;

namespace UESAN.Couch.Core.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IUsuariosRepository _usuariosRepository;

        private readonly IJWTFactory _jwtFactory;
        public UsuariosServices(IUsuariosRepository usuariosRepository, IJWTFactory jWTFactory)
        {
            _usuariosRepository = usuariosRepository;
            _jwtFactory = jWTFactory;
        }
        //goo
        public async Task<UserAuthResponseDTO> Validate(string email, string password)
        {
            var user = await _usuariosRepository.SignIn(email, password);
            if (user == null)
                return null;

            var token = _jwtFactory.GenerateJWToken(user);

            var UsuariosDTO = new UserAuthResponseDTO()
            {
                IdPersona = user.IdPersona,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Genero = user.Genero,
                NroContacto = user.NroContacto,
                CorreoElectronico = user.CorreoElectronico,
                Contrasena = user.Contrasena,
                Token = token
            };
            return UsuariosDTO;
        }

        public async Task<bool> Register(UserAuthRequestDTO UsuariosDTO)
        {
            //Validación para registro
            var emaiResult = await _usuariosRepository.IsEmailRegistered(UsuariosDTO.CorreoElectronico);
            if (emaiResult)
                return false;
//modificando
            var usuarios = new Usuarios()
            {
                IdPersona = UsuariosDTO.IdPersona,
                Nombre = UsuariosDTO.Nombre,
                Apellido = UsuariosDTO.Apellido,
                Genero = UsuariosDTO.Genero,
                NroContacto = UsuariosDTO.NroContacto,
                CorreoElectronico = UsuariosDTO.CorreoElectronico,
                Contrasena = UsuariosDTO.Contrasena,
              //  IdTipoNavigation = new TipoUsuario()
                //{
              //      TipoUsuario.Coach = UsuariosDTO.IdTipo                
               // },
                IsActive = true
                
            };

            var result = await _usuariosRepository.SignUp(usuarios);
            return result;
        }
    }
}


    
