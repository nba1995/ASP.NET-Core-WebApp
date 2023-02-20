using Corsi.Models.ViewModels;

namespace Corsi.Models.Services.Application
{
    //Che dati ho bisogno nel controller?
    //Qui definisco i metodi che poi implemento nel controller
    public interface ICourseService
    {
         List<CourseViewModel> GetCourses();

         CourseDetailViewModel GetCourse(int id);
    }
}