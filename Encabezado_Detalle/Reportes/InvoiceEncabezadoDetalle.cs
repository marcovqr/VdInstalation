using System.ComponentModel.DataAnnotations.Schema;

namespace Encabezado_Detalle.Reportes
{
    [NotMapped]
    public class InvoiceEncabezadoDetalle
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public string nit { get; set; }
        public string cliente { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public decimal Total { get; set; }
        public List<InvoiceDetalle> Detalles { get; set; }
    }
}
