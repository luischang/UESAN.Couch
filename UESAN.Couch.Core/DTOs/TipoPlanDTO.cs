using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Couch.Core.DTOs
{
    public class TipoPlanDTO
    {
        public int IdPlan { get; set; }
        public string? NombrePlan { get; set; }
    }

    public class TipoPlanInsertDTO
    {
        public string? NombrePlan { get; set; }
    }

    public class TipoPlanUpdateDTO
    {
        public int IdPlan { get; set; }
        public string? NombrePlan { get; set; }
    }
}
