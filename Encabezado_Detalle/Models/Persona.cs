using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Encabezado_Detalle.Models
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string nit { get; set; }
        [Required]
        [StringLength(50)]
        public string apellidos { get; set; }
        [Required]
        [StringLength(50)]
        public string nombres { get; set; }
        [Required]
        [StringLength(50)]
        public string direccion { get; set; }
        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        
        //public virtual ICollection<Cliente> clientes { get; set; }
    }
}
