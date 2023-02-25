using System.Data;

namespace Corsi.Models.ViewModels
{
    public class LessonViewModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }

        internal static LessonViewModel FromDataRow(DataRow lessonRow)
        {
            var lesson = new LessonViewModel{
                Title = Convert.ToString(lessonRow["Title"]),
                Duration = TimeSpan.Parse(Convert.ToString(lessonRow["Duration"]))
            };

            return lesson;
        }
    }
}