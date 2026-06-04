using AppStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILibroService libroService;

        public HomeController(ILibroService libroService)
        {
            this.libroService = libroService;
        }


        public IActionResult Index(string term="" , int currentPage = 1)
        {
            var libroListVm =  libroService.List(term, true, currentPage);
            return View(libroListVm);
        }

        public IActionResult LibroDetail(int libroId)
        {
            var libro = libroService.GetById(libroId);
            return View(libro);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}