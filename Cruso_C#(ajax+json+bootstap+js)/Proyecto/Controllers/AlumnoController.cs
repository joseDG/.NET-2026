using Microsoft.AspNetCore.Mvc;
using Proyecto.Datos;

namespace Proyecto.Controllers
{
    public class AlumnoController : Controller
    {

        private readonly AppDbContext _db;

        public AlumnoController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        //listar alumnos
        public JsonResult listarAlumnos()
        {
            var lista = (_db.Alumno.Where(p => p.BHABILITADO.Equals(1))
                .Select(p => new
                {
                    p.IIDALUMNO,
                    p.NOMBRE,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.TELEFONOPADRE
                })).ToList();

            return Json(lista);
        }

        //listar sexo
        public JsonResult listarSexo()
        {
            var lista = (_db.Sexo.Where(s => s.BHABILITADO.Equals(1))
                .Select(p => new
                {
                    IDD = p.IIDSEXO,
                    p.NOMBRE
                })).ToList();

            return Json(lista);
        }

        //Filtrar alumnos por sexo
        public JsonResult filtrarAlumnosPorSexo(int iidSexo)
        {
            var lista = (_db.Alumno.Where(p => p.BHABILITADO.Equals(1) 
            && p.IIDSEXO.Equals(iidSexo))
                .Select(p => new
                {
                    p.IIDALUMNO,
                    p.NOMBRE,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.TELEFONOPADRE
                })).ToList();
            return Json(lista);
        }
    }
}
