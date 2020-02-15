using System;
using agos_api.Models.Organizations;
using agos_api.Models.Studying;

namespace agos_api.Models.Schedule
{

    public class Semestr
    {
        public int SemestrId { get; set; }              // Id 1-го семестра в год
        public string CourseNum { get; set; }           // Курс/Год обучения
        public Speciality Speciality { get; set; }      // Ссылка на Speciality (Специальность)
        public string SemestrNum { get; set; }          // Номер семестра в году (1,2)
        public DateTime BeginOfSemestr { get; set; }    // Дата начало семестра (праздничные недели включительно)
        public DateTime FinishOfSemestr { get; set; }   // Дата конца семестра (праздничные недели включительно)
        public string HoursWeek { get; set; }           // Общее количество часов за семестр
        public StudyOrganization StudyOrganization { get; set; }
    }
}