using agos_api.Models.Organizations;

namespace agos_api.Models.Studying
{
    public class ClassificationSpeciality
    {
        public int ClassificationSpecialityId { get; set; }  // Id Специальностей отделений/факультетов
        public Classification classification { get; set; }  //  Ссылка на Classification
        public Speciality Speciality { get; set; }          // Ссылка на Speciality - специальность
    }
}