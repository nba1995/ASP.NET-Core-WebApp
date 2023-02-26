using System.Data;
using Corsi.Models.Services.Infrastracture;
using Corsi.Models.ViewModels;

namespace Corsi.Models.Services.Application
{
    // Perchè ADO net?
    // Tecnologia basata su provider (scaricabile da nuget)
    // Posso connettermi a n database cambiando il provider
        // SQLite       - dotnet add package Microsoft.Data.SQLite
        // SQL Server   - dotnet add package System.Data.SqlClient
        // MySql        - dotnet add package MySqlConnector
        // Oracle       - dotnet add package Oracle.ManageDataAccess.Core
        // PostgreSQL   - dotnet add package Npgsql

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

        public CourseDetailViewModel GetCourse(int id)
        {
            //string sqlInjectionID = "5; DROP TABLE Courses";
            
            FormattableString query = $@"SELECT Id, Title, Description, ImagePath, Author, Rating, FullPrice_Amount, CurrentPrice_Amount 
                            FROM Courses WHERE Id={id}; 
                            SELECT Id, Title, Description, Duration FROM Lessons WHERE CourseId={id}";
            
            DataSet dataSet = Db.Query(query);

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

        public List<CourseViewModel> GetCourses()
        {
            FormattableString query = $"SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Amount, CurrentPrice_Amount  FROM Courses";
            DataSet dataSet = Db.Query(query);

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