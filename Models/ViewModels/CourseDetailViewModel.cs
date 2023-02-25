using System.Data;

namespace Corsi.Models.ViewModels
{
    public class CourseDetailViewModel : CourseViewModel
    {
        public string Description { get; set; }
        public TimeSpan TotalCourseDuration 
        { 
            get => TimeSpan.FromSeconds(Lessons?.Sum(l=>l.Duration.TotalSeconds) ?? 0); 
        }

        public List<LessonViewModel> Lessons { get; set; } = new List<LessonViewModel>();

        internal static CourseDetailViewModel FromDataRow(DataRow courseRow)
        {
            var courseDetailViewModel = new CourseDetailViewModel{
                Id = Convert.ToInt32(courseRow["Id"]),
                Title = Convert.ToString(courseRow["Title"]),
                Description = Convert.ToString(courseRow["Description"]),
                ImagePath = Convert.ToString(courseRow["ImagePath"]),
                Author = Convert.ToString(courseRow["Author"]),
                Rating = Convert.ToDouble(courseRow["Rating"]),
                FullPrice = Convert.ToString(courseRow["FullPrice_Amount"]),
                CurrentPrice = Convert.ToString(courseRow["CurrentPrice_Amount"]),
            };
            
            return courseDetailViewModel;
        }
    }
}