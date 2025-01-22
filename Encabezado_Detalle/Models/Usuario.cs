namespace Encabezado_Detalle.Models
{
    public class Usuario : Persona
    {

        public string login { get; set; }
        public string rol { get; set; }
        public string? pass { get; set; }
        public string? estado { get; set; }
    }
}
