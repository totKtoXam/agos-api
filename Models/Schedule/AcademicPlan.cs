namespace agos_api.Models
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