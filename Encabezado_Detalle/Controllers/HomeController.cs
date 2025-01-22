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
                return Json(new { respuesta = true });
            }
            catch (Exception )
            {
                return Json(new { respuesta = false });
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
                    //ViewBag.Message("Customer no Existe");
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
