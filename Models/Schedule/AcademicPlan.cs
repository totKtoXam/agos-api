using agos_api.Models.Organizations;
using agos_api.Models.Studying;
using Microsoft.AspNetCore.Http;

namespace agos_api.Models.Schedule
{
    public class AcademicPlan
    {
        public int AcademicPlanId { get; set; }                 // Id академиского плана обучения

        public Semestr Semestr { get; set; }                    // Ссылка на Semestr (информация о семестре)

        public DisciplineSpecial DisciplineSpecial { get; set; }// Ссылка на DisciplineSpecial (Дисциплина/предмет обучения для специальности/факультет)
        
        public string AllHours { get; set; }                    // Общее количество часов обучения по определенной дисциплине за весь семестр
        public StudyOrganization StudyOrganization { get; set; }
    }

    public class AcademicPlanViewModel
    {
        public Semestr Semestr { get; set; }
        public IFormFile acPlanfile { get; set; }
        public StudyOrganization StudyOrganization { get; set; }
    }
}