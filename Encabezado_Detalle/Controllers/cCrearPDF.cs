using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Encabezado_Detalle.Controllers
{
    public class cCrearPDF : Controller
    {
        [HttpPost]
        public IActionResult creaPDF()
        {
            return new ViewAsPdf("CreaPDF"){
                //PageSize=Rotativa.AspNetCore.Options.Size.A4,
                //PageOrientation=Rotativa.AspNetCore.Options.Orientation.Landscape //horizontal
                //FileName="Invoice.pdf"
            };
        }
    }
}
