using agos_api.Models.Organizations;

namespace agos_api.Models
{
    public class SpecialityOtdel
    {
        public int SpecialityOtdelId { get; set; }
        public Otdel Otdel { get; set; }
        public Speciality Speciality { get; set; }
    }
}