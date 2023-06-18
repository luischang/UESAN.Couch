using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.DTOs
{
    public class EmprendadoresDTO
    {
        public int IdEmprendedor { get; set; }

        public int? IdPersona { get; set; }

        public bool? IsActive { get; set; }
        
    }
    public class EmprendadoresDescDTOS
    {
        public int IdEmprendedor { get; set; }

        public int? IdPersona { get; set; }


    }
    public class EmprendadoresInDTO
    {
        public int? IdPersona { get; set; }

        public bool? IsActive { get; set; }
    }




}
