using Corsi.Models.ViewModels;

namespace Corsi.Models.Services.Application
{
    public class CourseService : ICourseService
    {
        public List<CourseViewModel> GetCourses()
        {
            return new List<CourseViewModel>(){
                new CourseViewModel(){
                    Id = 1,
                    Title = "Titolo 1",
                    Author = "Autore 1",
                    FullPrice = "12",
                    CurrentPrice = "8",
                    Rating = 2
                }
            };
        }

        public CourseDetailViewModel GetCourse(int id)
        {
            var course = new CourseDetailViewModel{
                Id = id,
                Title = $"Corso {id}",
                CurrentPrice = "8",
                FullPrice = "10",
                Author = "Autore",
                Rating = 3.7,
                ImagePath = "/logo.svg",
                Description = $"Descrizione {id}",
                Lessons = new List<LessonViewModel>()
            };

            for(int i = 1; i<=5;i++)
            {
                var lesson = new LessonViewModel{
                    Title = $"Lezione {i}",
                    Duration = TimeSpan.FromSeconds(new Random().Next(40,90))
                };
                
                course.Lessons.Add(lesson);
            }

            return course;
        }
    }
}