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
    public class UsuariosAuthResponseDTO
    {
        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
        public string? NroContacto { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public bool? IsActive { get; set; }
        public int? IdTipo { get; set; }
        public string? Token { get; set; }
    }
    public class UsuariosAuthRequestDTO
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
        public string? NroContacto { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public bool? IsActive { get; set; }
        public int? IdTipo { get; set; }
    }
    public class UsuariosAuthenticacionDTO
    {
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
    }

}

