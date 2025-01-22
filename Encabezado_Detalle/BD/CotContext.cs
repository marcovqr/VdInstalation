using Encabezado_Detalle.Models;
using Microsoft.EntityFrameworkCore;

namespace Encabezado_Detalle.BD
{
    public class CotContext : DbContext
    {
        //Constructor creado para pasar la coneccion al padre clase DbContext
        public CotContext(DbContextOptions<CotContext> options)
        : base(options)
        {
        }
        //fin del constructor
        public DbSet<cot_cotizacion> Cotizaciones { get; set; } = null!;
        public DbSet<cot_cotizacion_item> Cot_Cotizacion_Items { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; }
        

        //para indicar los nombres que tendran las Tablas en la BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cot_cotizacion>().ToTable("cot_cotizacion");
            modelBuilder.Entity<cot_cotizacion_item>().ToTable("cot_cotizacion_item");
            modelBuilder.Entity<Persona>().ToTable("persona");
        }
    }
}
