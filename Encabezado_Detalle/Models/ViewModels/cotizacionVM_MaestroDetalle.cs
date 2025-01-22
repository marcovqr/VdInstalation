namespace Encabezado_Detalle.Models.ViewModels
{
    public class cotizacionVM_MaestroDetalle
    {
        public cot_cotizacion oCotizacion { get; set; }
        public List<cot_cotizacion_item> oDetalleCotizacion { get; set; }
        //public Persona oPersona { get; set; }
    }
}
