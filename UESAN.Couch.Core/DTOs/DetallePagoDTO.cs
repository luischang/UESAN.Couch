using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.DTOs
{
    public class DetallePagoDTO
    {
        public int IdDetpago { get; set; }
        public int? IdPago { get; set; }
        public int? IdDetCoachServicio { get; set; }
        public int? NroSolicitudes { get; set; }
        public virtual DetalleCoachServicio? IdDetCoachServicioNavigation { get; set; }
        public virtual Pago? IdPagoNavigation { get; set; }
    }

    public class DetallePagoInsertDTO
    {
        public int? IdPago { get; set; }
        public int? IdDetCoachServicio { get; set; }
        public int? NroSolicitudes { get; set; }
    }

    public class DetallePagoUpdateDTO
    {
        public int IdDetpago { get; set; }
        public int? IdPago { get; set; }
        public int? IdDetCoachServicio { get; set; }
        public int? NroSolicitudes { get; set; }
    }

    public class DetallePagoListDTO
    {
        public int IdDetpago { get; set; }
        public DetalleCouchServicioDTO CouchServicioDTO { get; set; }
        public PagoDTO PagoDTO { get; set; }
    }
}
