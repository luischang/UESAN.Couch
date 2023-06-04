
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UESAN.Couch.Core.DTOs
{
    public class ServiciosCoachingDTO
    {
        public int IdServicio { get; set; }

        public string? NombreServicio { get; set; }

        
    }

    public class ServiciosCoachingDescriptionDTO
    {
        public int IdServicio { get; set; }

        public string? NombreServicio { get; set; }


    }

    public class ServiciosCoachingInsertDTO
    {
        public string? NombreServicio { get; set; }


    }
}


