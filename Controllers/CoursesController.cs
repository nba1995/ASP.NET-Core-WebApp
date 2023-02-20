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
        public IActionResult Index()
        {
            ViewData["Title"] = "Elenco corsi";
            List<CourseViewModel> courses = courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Detail(int id)
        {
            ViewData["Title"] = "Dettaglio corso " + id.ToString();
            CourseDetailViewModel courseDetail = courseService.GetCourse(id);
            return View(courseDetail);
        }
    }
}