using Encabezado_Detalle.BD;
using Encabezado_Detalle.Migrations;
using Encabezado_Detalle.Models;
using Encabezado_Detalle.Models.ViewModels;
using Encabezado_Detalle.Reportes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Encabezado_Detalle.Controllers
{
    public class cCotizacion: Controller
    {
        private CotContext _context;
        public cCotizacion(CotContext context)
        {
            _context = context;
        }
        public IActionResult ListarCotizaciones(DateTime inicio, DateTime fin)
        {
           
            return View();

        }
        public ActionResult Detalles(int id)
        {
            var enca = _context.Cotizaciones.Include("Detalles")
                .FirstOrDefault(f => f.id == id);

            if (enca == null)
                return NotFound();

            return PartialView("_DetalleCotizacion", enca);
        }
        public JsonResult Listar(DateTime inicio, DateTime fin)
        {
            //Coloca en una lista en encabezado con sus respectivos datalles
            List<cot_cotizacion> listacot_cotizacion = new List<cot_cotizacion>();
                var datos=_context.Cotizaciones.Include(x => x.detalles).Include(x => x.personas)
                                                       //.Where(x => x.Fecha >= inicio && x.Fecha <= fin)
                                                       .Where(x => x.Fecha >= inicio && x.Fecha <= fin && x.estado=="OK")
                                                       .Select(x => new
                                                        {
                                                            Id=x.id,
                                                            fecha = x.Fecha.ToString("yyyy-MM-dd"),
                                                            //nombres = x.personas.nombres,
                                                            //nit=x.personas.nit,
                                                            //direccion = x.personas.direccion,
                                                            //Telefono = x.personas.Telefono,
                                                            nombres=x.customer,
                                                            direccion=x.adress,
                                                            Telefono=x.telf,
                                                            Po=x.Po,
                                                            Total = x.Total
                                                           //detalles = string.Join(", ", x.detalles.Select(d => d.Descripcion)) // Concatenar detalles

                                                       }).ToList();
            //string json = JsonSerializer.Serialize(listacot_cotizacion);            
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Formato legible
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };

            // Serializar a JSON
            string json = JsonSerializer.Serialize(datos, options);
            Console.WriteLine(json);
            // Retorna la lista como un objeto JSON
            return new JsonResult(datos, options);
        }
        public JsonResult GetDetalleReporte(int id)
        {
            #region[Detalle de Invoice]
            try
             {
               InvoiceEncabezadoDetalle enca = new InvoiceEncabezadoDetalle();
               InvoiceDetalle detalle = new InvoiceDetalle();
                enca.Id = id;
                var datos = _context.Cot_Cotizacion_Items.Where(x=>x.id_cot_cotizacion==id)
                                                         .Select(x => new
                                                         {
                                                             Id = x.id,
                                                             Fecha=x.Fecha.Value.ToShortDateString(),
                                                             Store=x.Store,
                                                             ProductoNombre = x.ProductoNombre,
                                                             Cantidad = x.Cantidad,
                                                             Precio = x.Precio,
                                                             id_cot_cotizacion=x.id_cot_cotizacion
                                                         }).ToList();
                     
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true, // Formato legible
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
                };
                // Serializar a JSON
                string json = JsonSerializer.Serialize(datos, options);
                Console.WriteLine(json);
                // Retorna la lista como un objeto JSON
                return new JsonResult(datos, options);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
            #endregion
        }
        public IActionResult ListarInvoiceTotales()
        {
            return View();
        }
        public JsonResult ListarTotales(int inicio, int fin)
        {
            //Coloca en una lista en encabezado con sus respectivos datalles
            List<cot_cotizacion> listacot_cotizacion = new List<cot_cotizacion>();
            var datos = _context.Cotizaciones.Include(x => x.detalles).Include(x => x.personas)
                                                   .Where(x => x.id >= inicio && x.id <= fin && x.estado == "OK")
                                                   .Select(x => new
                                                   {
                                                       Id = x.id,
                                                       fecha = x.Fecha.ToString("yyyy-MM-dd"),
                                                       Total = x.Total
                                                     

                                                   }).ToList();
            //string json = JsonSerializer.Serialize(listacot_cotizacion);            
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Formato legible
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };

            // Serializar a JSON
            string json = JsonSerializer.Serialize(datos, options);
            Console.WriteLine(json);
            // Retorna la lista como un objeto JSON
            return new JsonResult(datos, options);
        }
        
    }
}
