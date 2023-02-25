using System.Data;

namespace Corsi.Models.ViewModels
{
    public class CourseViewModel
    {
        // Struttura dati per la view
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; }
        public string FullPrice { get; set; }
        public string CurrentPrice { get; set; }

        internal static CourseViewModel FromDataRow(DataRow courseRow)
        {
            //Id, Title, ImagePath, Author, Rating, FullPrice_Amount, CurrentPrice_Amount

            var courseViewModel = new CourseViewModel{
                Id = Convert.ToInt32(courseRow["Id"]),
                Title = Convert.ToString(courseRow["Title"]),
                ImagePath = Convert.ToString(courseRow["ImagePath"]),
                Author = Convert.ToString(courseRow["Author"]),
                Rating = Convert.ToDouble(courseRow["Rating"]),
                FullPrice = Convert.ToString(courseRow["FullPrice_Amount"]),
                CurrentPrice = Convert.ToString(courseRow["CurrentPrice_Amount"]),
            };

            return courseViewModel;
        }
    }
}