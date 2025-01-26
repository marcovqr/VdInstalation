using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encabezado_Detalle.Models
{
    public class cot_cotizacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        // Relación con Persona
        public int id_persona { get; set; }
        [ForeignKey("id_persona")]
        public virtual Persona personas { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? customer { get; set; }
        [StringLength(150)]
        public string? adress { get; set; }
        [StringLength(50)]
        public string? telf { get; set; }
        [StringLength(50)]
        public string? Po { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public virtual ICollection<cot_cotizacion_item> detalles { get; set; }
        //public virtual ICollection<Persona> Clientes { get; set; }
    }
}
