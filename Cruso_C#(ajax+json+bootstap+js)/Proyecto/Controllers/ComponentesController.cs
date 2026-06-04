using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class ComponentesController : Controller
    {
        public IActionResult Tabla()
        {
            return View();
        }

        public IActionResult ComboBox() {
            return View();
        }

        public ActionResult TablaJs() {
            return View();
        }

        public JsonResult listarPersonas() {
            var personas = new List<Models.Persona> {
                new Models.Persona { Id = 1, Nombre = "Juan", Apellido = "Pérez" },
                new Models.Persona { Id = 2, Nombre = "María", Apellido = "Gómez" },
                new Models.Persona { Id = 3, Nombre = "Carlos", Apellido = "López" }
            };
            return Json(personas);
        }
    }
}
