using Encabezado_Detalle.BD;
using Encabezado_Detalle.Models;
using Encabezado_Detalle.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Encabezado_Detalle.Controllers
{
    public class HomeController : Controller
    {
        private CotContext _context;

        public HomeController(CotContext context)
        {
        _context = context;
        }

        public IActionResult Index()
        {
           //Coloca en una lista en encabezado con sus respectivos datalles
            List<cot_cotizacion> listacot_cotizacion = _context.Cotizaciones.Include(x=>x.detalles).Include(x=>x.personas).ToList();
            return View(listacot_cotizacion);
            
        }
        //Controlador que recibe datos desde la Vista
        [HttpPost]
        public IActionResult Index([FromBody] cotizacionVM_MaestroDetalle oCotizacionVM)
        {
            try
            {
                cot_cotizacion oCotizacion = oCotizacionVM.oCotizacion;
                oCotizacion.detalles = oCotizacionVM.oDetalleCotizacion;
                _context.Cotizaciones.Add(oCotizacion);
                _context.SaveChanges();

                // Retornar JSON con una URL para el PDF
                string pdfUrl = Url.Action("GenerarPdf", "Home", new { id = oCotizacion.id }, Request.Scheme);
                return Json(new { respuesta = true, pdfUrl });
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = false, error = ex.Message });
                throw;
                

            }
           
           
        }
        // Acción para generar el PDF con Rotativa
        public IActionResult GenerarPdf(int id)
        {
            // Buscar la cotización en la base de datos
            var oCotizacion = _context.Cotizaciones
                .Include(c => c.detalles) // Incluir los detalles relacionados
                .FirstOrDefault(c => c.id == id);

            if (oCotizacion == null)
            {
                return NotFound("Invoice not found.");
            }

            // Generar el PDF usando Rotativa
            return new Rotativa.AspNetCore.ViewAsPdf("creaPDF", oCotizacion)
            {
                //FileName = $"Cotizacion_{oCotizacion.id}.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--disable-smart-shrinking"
            };
        }
        public IActionResult GeneraPDF_Listado(int id)
        {
            try
            {
                // Buscar la cotización en la base de datos
                var oCotizacion = _context.Cotizaciones
                    .Include(c => c.detalles) // Incluir los detalles relacionados
                    .FirstOrDefault(c => c.id == id);

                if (oCotizacion == null)
                {
                    return NotFound("Invoice not found.");
                }
                // Retornar JSON con una URL para el PDF
                string pdfUrl = Url.Action("GenerarPdf", "Home", new { id = oCotizacion.id }, Request.Scheme);
                return Json(new { respuesta = true, pdfUrl });
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = false, error = ex.Message });
                throw;


            }


        }
        public IActionResult vCrearCotizacion()
        {
            //Coloca en una lista en encabezado con sus respectivos datalles
            List<cot_cotizacion> listacot_cotizacion = _context.Cotizaciones.Include(x => x.detalles).Include(x => x.personas).ToList();
            return View(listacot_cotizacion);

        }

        [HttpGet]
        public JsonResult _buscaPersona(String nit)
        {
            Persona model = new Persona();

            try
            {
                List<Persona> resultado = (from u in _context.Personas
                                           where u.nit == nit
                                           select u).ToList();

                //var resultado = db.customer.Find(cedula);
                if (resultado == null || resultado.Count() > 0)
                {
                    model.Id = resultado.ElementAt(0).Id;
                    model.nit = resultado.ElementAt(0).nit.Trim();
                    model.nombres = resultado.ElementAt(0).nombres.Trim();
                    model.apellidos = resultado.ElementAt(0).apellidos.Trim();
                    model.direccion = resultado.ElementAt(0).direccion.Trim();
                    model.Telefono = resultado.ElementAt(0).Telefono.Trim();
                }
                else
                {
                   // ViewBag.Message("Customer no Existe");
                    return Json(model);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Json(model);

        }


    }
}
