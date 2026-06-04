using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Datos;
using System.Threading.Tasks;

namespace Proyecto.Controllers
{
    public class CursoController : Controller
    {

        private readonly AppDbContext _db;

        public CursoController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult recuperarDatos(int id)
        {
            var lista = _db.Cursos
                .AsNoTracking()
                .Where(p => p.IIDCURSO == id)
                .Select(p => new { p.IIDCURSO, p.NOMBRE, p.DESCRIPCION })
                .ToList();
            return Json(lista);
        }

        public JsonResult ListarCurso()
        {
            var lista = _db.Cursos
                .AsNoTracking()
                .Where(p => p.BHABILITADO == 1)
                .Select(p => new { p.IIDCURSO, p.NOMBRE, p.DESCRIPCION })
                .ToList();

            return Json(lista);
        }

        //Buscar curso por id
        public JsonResult buscarCursoPorNombre(string nombre)
        {
            var busqueda = _db.Cursos
                .AsNoTracking()
                .Where(p => p.BHABILITADO.Equals(1) && p.NOMBRE.Contains(nombre))
                .Select(p => new { p.IIDCURSO, p.NOMBRE, p.DESCRIPCION })
                .ToList();

            return Json(busqueda);
        }

       
    }
}
