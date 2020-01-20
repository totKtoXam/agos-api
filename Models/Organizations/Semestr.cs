namespace agos_api.Models 
{

        public class Semestr
    {

        public int SemestrId { get; set; }
        public string CourseNum { get; set; }
        public Speciality Speciality { get; set; }
        public string SemestrNum { get; set; }
        public string BeginOfSemestr { get; set; }
        public string FinishOfSemestr { get; set; }
        public string HoursWeek { get; set; }
    }
}