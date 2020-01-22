using agos_api.Models.Organizations;

namespace agos_api.Models.Schedule
{
    public class AcademicPlan
    {
        public int AcademicPlanId { get; set; }                 /// Id академиского плана обучения

        public Semestr Semestr { get; set; }                    /// Ссылка на Semestr (информация о семестре)

        public Speciality Speciality { get; set; }              /// Ссылка на Speciality (Специальность/факультет)

        public DisciplineSpecial DisciplineSpecial { get; set; }/// Ссылка на DisciplineSpecial (Дисциплина/предмет обучения для специальности/факультет)
        
        public string AllHours { get; set; }                    /// Общее количество часов обучения по определенной дисциплине за весь семестр
    }
}