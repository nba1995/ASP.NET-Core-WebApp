namespace Corsi.Models.ViewModels
{
    public class CourseDetailViewModel : CourseViewModel
    {
        public string Description { get; set; }
        public TimeSpan TotalCourseDuration 
        { 
            get => TimeSpan.FromSeconds(Lessons?.Sum(l=>l.Duration.TotalSeconds) ?? 0); 
        }

        public List<LessonViewModel> Lessons { get; set; }
    }
}