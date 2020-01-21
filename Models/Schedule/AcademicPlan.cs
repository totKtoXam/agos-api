using agos_api.Models.Organizations;

namespace agos_api.Models.Schedule
{
    public class AcademicPlan
    {
        public int AcademicPlanId { get; set; }

        public Semestr Semestr { get; set; }

        public Speciality Speciality { get; set; }

        public DisciplineSpecial DisciplineSpecial { get; set; }
        
        public string AllHours { get; set; }
    }
}