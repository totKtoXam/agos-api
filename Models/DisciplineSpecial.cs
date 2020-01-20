namespace agos_api.Models
{
    public class DisciplineSpecial 
    {
        public int DisciplineSpecialId { get; set; }
        public SpecialityOtdel SpecialityOtdel { get; set;}
        public Discipline Discipline { get; set; }

    }
}