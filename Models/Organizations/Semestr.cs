using System;

namespace agos_api.Models.Organizations
{

        public class Semestr
    {

        public int SemestrId { get; set; }
        public string CourseNum { get; set; }
        public Speciality Speciality { get; set; }
        public string SemestrNum { get; set; }
        public DateTime BeginOfSemestr { get; set; }
        public DateTime FinishOfSemestr { get; set; }
        public string HoursWeek { get; set; }
    }
}