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

        public CourseDetailViewModel GetCourse(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseViewModel> GetCourses()
        {
            string query = "SELECT * FROM Courses";
            DataSet dataSet = Db.Query();

            throw new NotImplementedException();
        }
    }
}