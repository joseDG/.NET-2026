using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Datos;

namespace Proyecto.Controllers
{
    public class DocenteController : Controller
    {

        private readonly AppDbContext _db;

        public DocenteController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult listarDocente() {
            var lista = (from docente in _db.Docente
                         where docente.BHABILITADO.Equals(1)
                         select new
                         {
                             docente.IIDDOCENTE,
                             docente.NOMBRE,
                             docente.APPATERNO,
                             docente.APMATERNO,
                             docente.EMAIL
                         }).ToList();
            return Json(lista);
        }

        public JsonResult filtrarDocentePorModalidad(int iidmodalidad)
        {
            var lista = (from docente in _db.Docente
                         where docente.BHABILITADO.Equals(1) && docente.IIDMODALIDADCONTRATO.Equals(iidmodalidad)
                         select new
                         {
                             docente.IIDDOCENTE,
                             docente.NOMBRE,
                             docente.APPATERNO,
                             docente.APMATERNO,
                             docente.EMAIL
                         }).ToList();
            return Json(lista);
        }

        public JsonResult listarModalidadContrato() 
        {
            var lista = _db.ModalidadContrato
                .AsNoTracking()
                .Where(d => d.BHABILITADO.Equals(1))
                .Select(d => new
                {
                    IDD = d.IIDMODALIDADCONTRATO,
                    d.NOMBRE
                }).ToList();

            return Json(lista);
        }
    }
}
