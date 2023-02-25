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
            throw new NotImplementedException();
        }

        public List<CourseViewModel> GetCourses()
        {
            string query = "SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Amount, CurrentPrice_Amount  FROM Courses";
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