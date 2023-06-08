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

        public async Task<bool> RegisterCoach(UserAuthRequestDTO UsuariosDTO)
        {
            //Validación para registro
            var emaiResult = await _usuariosRepository.IsEmailRegistered(UsuariosDTO.CorreoElectronico);
            if (emaiResult)
                return false;
            //modificando esta parte 
            var usuarios = new Usuarios()
            {
              
                IdPersona = UsuariosDTO.IdPersona,
                Nombre = UsuariosDTO.Nombre,
                Apellido = UsuariosDTO.Apellido,
                Genero = UsuariosDTO.Genero,
                NroContacto = UsuariosDTO.NroContacto,
                CorreoElectronico = UsuariosDTO.CorreoElectronico,
                Contrasena = UsuariosDTO.Contrasena,
                //ojo con es
                IsActive = true,
                //quiero que me traiga el id del tipo de usuario

                IdTipo = new TiposUsuario()//esto me trae el id del tipo de usuario
                {
                  IdTipo = '1',//con esto me trae el id del tipo de usuario
                }
               

            };

            var result = await _usuariosRepository.SignUpCoach(usuarios);
            return result;
        }



        public async Task<bool> RegisterEmprendedor(UserAuthRequestDTO UsuariosDTO )
        {
            //Validación para registro
            var emaiResult = await _usuariosRepository.IsEmailRegistered(UsuariosDTO.CorreoElectronico);
            if (emaiResult)
                return false;
            //modificando esta parte 
            var usuarios = new Usuarios()
            {
                IdPersona = UsuariosDTO.IdPersona,
                Nombre = UsuariosDTO.Nombre,
                Apellido = UsuariosDTO.Apellido,
                Genero = UsuariosDTO.Genero,
                NroContacto = UsuariosDTO.NroContacto,
                CorreoElectronico = UsuariosDTO.CorreoElectronico,
                Contrasena = UsuariosDTO.Contrasena,                    
                IsActive = true,
                IdTipo = new TiposUsuario()
                {
                    IdTipo = '2',
                }
                
            };

            var result = await _usuariosRepository.SignUpEmprendedor(usuarios);
            return result;
        }
    }
}


    
