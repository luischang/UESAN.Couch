using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.DTOs
{
    public class UsuariosDTO
    {
        private object coach;
        //esto me sirve para poder hacer el join con la tabla de coach
        public enum TipoUsuario
        {
            Coach = 1,
            Emprendedor = 2
        }
        public UsuariosDTO(object coach)
        {
            this.coach = coach;
        }

        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
        public string? NroContacto { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public bool? IsActive { get; set; }
        public int? IdTipo { get; set; }

    }


    public class UserAuthResponseDTO
    {
        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
        public string? NroContacto { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public string? Token { get; set; }
    }

    public class UserAuthRequestDTO
    {
        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
        public string? NroContacto { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public int? IdTipo { get; set; }

        public class UsuariosDatosDTO
        {
            public int IdPersona { get; set; }

            public string? Nombre { get; set; }

            public string? Apellido { get; set; }

            public class UserAuthenticationDTO
            {
                public string? CorreoElectronico { get; set; }
                public string? Contrasena { get; set; }

            }

        }
    }
}

