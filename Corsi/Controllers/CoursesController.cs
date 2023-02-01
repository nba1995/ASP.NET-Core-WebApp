using Microsoft.AspNetCore.Mvc;

namespace Corsi.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return Content("Sono index");
        }

        public IActionResult Detail(string id)
        {
            return Content($"Sono detail, id {id}");
        }
    }
}