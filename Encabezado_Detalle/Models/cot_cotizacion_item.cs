using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encabezado_Detalle.Models
{
    public class cot_cotizacion_item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string? ProductoNombre { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Cantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Precio { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal => Cantidad * Precio;
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        [StringLength(50)]
        public string? Store { get; set; }
        // Relación con el detalle
        public int id_cot_cotizacion { get; set; }
        [ForeignKey("id_cot_cotizacion")]
        public virtual cot_cotizacion encabezado { get; set; }
    }
}
