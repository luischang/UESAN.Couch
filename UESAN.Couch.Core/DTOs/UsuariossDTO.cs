using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Couch.Core.DTOs
{
    public class UsuariossDTO
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

    public class UsuariosDatosDTO
    {
        public int IdPersona { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
    }

}
