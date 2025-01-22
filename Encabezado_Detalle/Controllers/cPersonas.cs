using Encabezado_Detalle.BD;
using Encabezado_Detalle.Models;
using Microsoft.AspNetCore.Mvc;

namespace Encabezado_Detalle.Controllers
{
    public class cPersonas : Controller
    {
        private CotContext _context;

        public cPersonas(CotContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult _buscaPersona(String cedula)
        {
            Persona model = new Persona();
         
                try
                {
                    List<Persona> resultado = (from u in _context.Personas
                                                where u.nit == cedula
                                                select u).ToList();

                    //var resultado = db.customer.Find(cedula);
                    if (resultado == null || resultado.Count() > 0)
                    {
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

