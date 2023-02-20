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
        
    }
}