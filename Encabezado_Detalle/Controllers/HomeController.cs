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
        #region[Creacion de invoice recibe datos de la vista.apenas se crea se genera el pdf.]
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
        #endregion
        #region[Metodo Global para crear el PDF]
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
        #endregion
        #region[Metodo para crear varios invoice en un solo PDF desde la vista,aki se llama la vista q ve el usuario ]
        //Genera varios invoice en un solo Pdf de un listado 
        public IActionResult GenerarPdf_global(string ids)
        {
            // Convertir los IDs en una lista
            var idList = ids.Split(',').Select(int.Parse).ToList();

            // Buscar las cotizaciones correspondientes a esos IDs
            var cotizaciones = _context.Cotizaciones
                .Include(c => c.detalles) // Incluir los detalles relacionados
                .Where(c => idList.Contains(c.id))
                .ToList();

            if (!cotizaciones.Any())
            {
                return NotFound("No se encontraron cotizaciones.");
            }

            // Generar el PDF usando Rotativa para todas las cotizaciones
            return new Rotativa.AspNetCore.ViewAsPdf("creaPDF_Global", cotizaciones)
            {
                //FileName = $"Invoice_{string.Join("_", idList)}.pdf", // Opcional: para generar un nombre de archivo con los IDs
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--disable-smart-shrinking"
            };
        }
        #endregion
        #region[Metodo global para generar pdf totalizado, aki se llama la vista q ve el usuario ]
        public IActionResult GeneraPDF_Total(int inicio,int fin)
        {
            // Buscar la cotización en la base de datos
            var oCotizacion = _context.Cotizaciones
                .Include(c => c.detalles) // Incluir los detalles relacionados
                .Where(c => c.id >= inicio && c.id <= fin && c.estado == "OK").ToList();

            if (oCotizacion == null || !oCotizacion.Any())
            {
                return NotFound("No se encontraron Invoice en ese rango.");
            }

            // Calcular el total de todas las cotizaciones
            oCotizacion.ElementAt(0).estado = oCotizacion.Sum(c => c.Total).ToString();  // Asumiendo que cada cotización tiene un campo Total
            //Console.WriteLine(ViewBag.Totalizado);
            // Generar el PDF usando Rotativa
            return new Rotativa.AspNetCore.ViewAsPdf("creaPDF_Totalizado", oCotizacion)
            {
                //FileName = $"Cotizacion_{oCotizacion.id}.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--disable-smart-shrinking"
            };
        }
        #endregion
        #region[Metodo para crear PDF totalizado segun rango de invoice que se ingresen en la vista ]
        public IActionResult GeneraPDF_Totalizado(int inicio , int fin)
        {
            try
            {
                if (inicio == 0 && fin ==0)
                {
                    return NotFound("Invoice not found.");
                }
                // Retornar JSON con una URL para el PDF
                string pdfUrl = Url.Action("GeneraPDF_Total", "Home", new { inicio = inicio,fin=fin }, Request.Scheme);
                return Json(new { respuesta = true, pdfUrl });
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = false, error = ex.Message });
                throw;
            }
        }
        #endregion
        #region[Metodo para crear varios invoice en un solo PDF recibe desde la vista lo seleccionado]
        public IActionResult GeneraPDF_Glo(string ids)
        {
            try
            {
                if (ids=="")
                {
                    return NotFound("Invoice not found.");
                }
                // Retornar JSON con una URL para el PDF
                string pdfUrl = Url.Action("GenerarPdf_global", "Home", new { ids }, Request.Scheme);
                return Json(new { respuesta = true, pdfUrl });
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = false, error = ex.Message });
                throw;
            }
        }
        #endregion
        #region[Metodo que recibe desde el listado un invoice para generar el PDF]
        public IActionResult GeneraPDF_Listado(int id)
        {
            try
            {
               
                if (id ==0)
                {
                    return NotFound("Invoice not found.");
                }
                // Retornar JSON con una URL para el PDF
                string pdfUrl = Url.Action("GenerarPdf", "Home", new { id = id }, Request.Scheme);
                return Json(new { respuesta = true, pdfUrl });
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = false, error = ex.Message });
                throw;
            }
        }
        #endregion
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
        #region[Eliminar Invoice]
        public async Task<bool> EliminarInvoice(int id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Buscar la cotización principal
                    var cotizacion = await _context.Cotizaciones.FindAsync(id);
                    if (cotizacion == null) return false; // Si no existe, no hay nada que eliminar.

                    // Buscar los detalles relacionados con la cotización
                    var detalles = await _context.Cot_Cotizacion_Items
                                                 .Where(d => d.id_cot_cotizacion == id)
                                                 .ToListAsync();

                    // Eliminar los detalles primero
                    if (detalles.Any())
                    {
                        _context.Cot_Cotizacion_Items.RemoveRange(detalles);
                    }

                    // Eliminar la cotización principal
                    _context.Cotizaciones.Remove(cotizacion);

                    await _context.SaveChangesAsync();

                    // Obtener el último ID válido de la tabla principal (cotizaciones)
                    var ultimoId = await _context.Cotizaciones.MaxAsync(x => (int?)x.id) ?? 0;

                    // Reiniciar el contador IDENTITY en la tabla cotizaciones
                    await _context.Database.ExecuteSqlRawAsync($"DBCC CHECKIDENT ('cot_cotizacion', RESEED, {ultimoId})");

                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine($"Error eliminando cotización: {ex.Message}");
                    return false;
                }
            }
        }

        #endregion
        #region[Elimina registro]
        [HttpPost]
        public async Task<IActionResult> EliminarRegistro(int id)
        {
            var resultado = await this.EliminarInvoice(id);
            if (resultado)
            {
                //return RedirectToAction("Index"); // O la vista que corresponda
                // Si el resultado es verdadero, devuelve un JSON con true
                return Json(new { respuesta = true, mensaje= "Invoice Anulado correctamente" });
            }
            // Si el resultado es falso, devuelve un mensaje de error
            return BadRequest(new { mensaje = "Error al eliminar el registro." });
        }
        #endregion

    }
}
