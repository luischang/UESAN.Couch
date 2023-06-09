using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.DTOs
{
    public class TiposUsuarioDTOS
    {
        public int IdTipo { get; set; }

        public string? NombreTipo { get; set; }

        public bool? IsActive { get; set; }
    }
    public class TiposUsuarioDescriptionDTO
    {
        public int IdTipo { get; set; }

        public string? NombreTipo { get; set; }
    }

    public class TiposUsuarioInsertDTO
    {
        public string? NombreTipo { get; set; }

        public bool? IsActive { get; set; }
    }
    public class TiposUsuarioUpdateDTO
    {
        public int IdTipo { get; set; }

        public string? NombreTipo { get; set; }

        public bool? IsActive { get; set; }
    }

}
