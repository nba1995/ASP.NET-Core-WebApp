using Corsi.Models.Services.Application;
using Corsi.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Corsi.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Elenco corsi";
            CourseService courseService =  new CourseService();
            List<CourseViewModel> courses = courseService.GetCourses();
            
            return View(courses);
        }

        public IActionResult Detail(int id)
        {
            ViewData["Title"] = "Dettaglio corso " + id.ToString();
            CourseService courseService =  new CourseService();
            CourseDetailViewModel courseDetail = courseService.GetCourse(id);
            
            return View(courseDetail);
        }
    }
}