using Corsi.Models.ViewModels;

namespace Corsi.Models.Services.Application
{
    //Che dati ho bisogno nel controller?
    //Qui definisco i metodi che poi implemento nel controller
    public interface ICourseService
    {
         Task<List<CourseViewModel>> GetCoursesAsync();

         Task<CourseDetailViewModel> GetCourseAsync(int id);
    }
}