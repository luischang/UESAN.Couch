using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.DTOs
{
    public class PagoDTO
    {
        public int IdPago { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual int? IdEmprendedorNavigation { get; set; }

        public decimal? TotalPago { get; set; }
        public bool? IsActive { get; set; }
    }
    public class PagoDescripDTO
    {
        public int IdPago { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public int? IdEmprendedor { get; set; }

        public decimal? TotalPago { get; set; }
    }
    public class PagoInDTO
    {
       
        public DateTime? FechaRegistro { get; set; }

        public int? IdEmprendedor { get; set; }

        public decimal? TotalPago { get; set; }
        public bool? IsActive { get; set; }

    }
    public class PagoUpDTO
    {
        public int IdPago { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public int? IdEmprendedor { get; set; }

        public decimal? TotalPago { get; set; }
        public bool? IsActive { get; set; }

    }


    public class PagoEmprendedorDTO
    {
        public int IdPago { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual EmprendadoresDescDTOS IdEmprendedorNavigation { get; set; }

        public decimal? TotalPago { get; set; }
        

       
    }   

}