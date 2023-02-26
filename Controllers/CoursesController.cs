using Corsi.Models.Services.Application;
using Corsi.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Corsi.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Elenco corsi";
            List<CourseViewModel> courses = await courseService.GetCoursesAsync();
            return View(courses);
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewData["Title"] = "Dettaglio corso " + id.ToString();
            CourseDetailViewModel courseDetail = await courseService.GetCourseAsync(id);
            return View(courseDetail);
        }
    }
}