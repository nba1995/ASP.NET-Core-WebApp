using Corsi.Models.ViewModels;

namespace Corsi.Models.Services.Application
{
    public class CourseService : ICourseService
    {
        public Task<List<CourseViewModel>> GetCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseDetailViewModel> GetCourseAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}