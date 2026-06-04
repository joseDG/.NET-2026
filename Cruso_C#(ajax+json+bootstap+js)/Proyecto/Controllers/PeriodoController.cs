using Microsoft.AspNetCore.Mvc;
using Proyecto.Datos;
using System.Globalization;

namespace Proyecto.Controllers
{
    public class PeriodoController : Controller
    {
        private readonly AppDbContext _db;

        public PeriodoController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult listarPeriodo() 
        {
            var lista = _db.Periodo
                .Where(p => p.BHABILITADO == 1)
                .Select(p => new { p.IIDPERIODO, p.NOMBRE, FECHAINICIO=((DateTime)p.FECHAINICIO).ToShortDateString() , FECHAFIN = ((DateTime)p.FECHAFIN).ToShortDateString() })
                .ToList();
            return Json(lista);
        }

        //Bsucar periodo por nombre
        public JsonResult buscarPeriodoPorNombre(string nombrePeriodo)
        {
            var lista = _db.Periodo
                .Where(p => p.BHABILITADO.Equals(1) && p.NOMBRE.Contains(nombrePeriodo))
                .Select(p => new { 
                    p.IIDPERIODO, 
                    p.NOMBRE, 
                    FECHAINICIO = ((DateTime)p.FECHAINICIO).ToShortDateString(), 
                    FECHAFIN = ((DateTime)p.FECHAFIN).ToShortDateString() })
                .ToList();
            return Json(lista);
        }
    }
}
