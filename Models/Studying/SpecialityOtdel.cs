using agos_api.Models.Organizations;

namespace agos_api.Models.Studying
{
    public class SpecialityOtdel
    {
        public int SpecialityOtdelId { get; set; }  // Id Специальностей отделений/факультетов
        public Otdel Otdel { get; set; }            // Ссылка на Otdel - отделения/факультеты
        public Speciality Speciality { get; set; }  // Ссылка на Speciality - специальность
    }
}