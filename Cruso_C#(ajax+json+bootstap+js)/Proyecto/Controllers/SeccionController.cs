using Microsoft.AspNetCore.Mvc;
using Proyecto.Datos;

namespace Proyecto.Controllers
{
    public class SeccionController : Controller
    {

        private readonly AppDbContext _db;

        public SeccionController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult listarSeccion()
        {
            var lista = _db.Seccion
                .Where(p => p.BHABILITADO == 1)
                .Select(p => new { p.IIDSECCION, p.NOMBRE })
                .ToList();
            return Json(lista);
        }
    }
}
