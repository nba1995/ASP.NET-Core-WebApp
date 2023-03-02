using System.Data;
using Corsi.Models.Services.Infrastracture;
using Corsi.Models.ViewModels;

namespace Corsi.Models.Services.Application
{
    // Servizio applicativo - Deve sapere COSA estrarre
    // Ad esempio quali corsi, quanti corsi
    public class AdoNetCourseService : ICourseService
    {
        // Dipende dal servizio infrastrutturale che avrà il compito di
        // sapere COME estrarre i dati dal DB (come eseguire le query).
        public AdoNetCourseService(IDatabaseAccess db)
        {
            Db = db;
        }

        public IDatabaseAccess Db { get; }

        public async Task<CourseDetailViewModel> GetCourseAsync(int id)
        {
            //string sqlInjectionID = "5; DROP TABLE Courses";

            FormattableString query = $@"SELECT Id, Title, Description, ImagePath, Author, Rating, FullPrice_Amount, CurrentPrice_Amount 
                            FROM Courses WHERE Id={id}; 
                            SELECT Id, Title, Description, Duration FROM Lessons WHERE CourseId={id}";
            
            DataSet dataSet = await Db.QueryAsync(query);

            //Course
            var courseTable = dataSet.Tables[0];
            if (courseTable.Rows.Count != 1) {
                throw new InvalidOperationException($"Did not return exactly 1 row for Course {id}");
            }
            var courseRow = courseTable.Rows[0];
            var courseDetailViewModel = CourseDetailViewModel.FromDataRow(courseRow);

            //Course lessons
            var lessonDataTable = dataSet.Tables[1];

            foreach(DataRow lessonRow in lessonDataTable.Rows) {
                LessonViewModel lessonViewModel = LessonViewModel.FromDataRow(lessonRow);
                courseDetailViewModel.Lessons.Add(lessonViewModel);
            }
            return courseDetailViewModel; 
        }

        public async Task<List<CourseViewModel>> GetCoursesAsync()
        {
            FormattableString query = $"SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Amount, CurrentPrice_Amount  FROM Courses";
            DataSet dataSet = await Db.QueryAsync(query);

            List<CourseViewModel> listCourseViewmModel = new List<CourseViewModel>();
            var dataTable = dataSet.Tables[0];
            foreach(DataRow courseRow in dataTable.Rows)
            {
                CourseViewModel course = CourseViewModel.FromDataRow(courseRow);
                listCourseViewmModel.Add(course);
            }

            return listCourseViewmModel;
        }
    }
}