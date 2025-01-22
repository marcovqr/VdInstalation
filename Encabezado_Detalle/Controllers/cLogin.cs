using Encabezado_Detalle.BD;
using Encabezado_Detalle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Encabezado_Detalle.Controllers
{
    public class cLogin : Controller
    {
        private CotContext _context;

        public cLogin(CotContext context)
        {
            _context = context;
        }
       

    }
}



