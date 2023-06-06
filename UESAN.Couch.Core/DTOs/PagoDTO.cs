namespace UESAN.Couch.Core.DTOs
{
    public class PagoDTO
    {
        public int IdPago { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdEmprendedor { get; set; }
        public decimal? TotalPago { get; set; }
    }
}