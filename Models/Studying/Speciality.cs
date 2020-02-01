namespace agos_api.Models.Studying
{
    public class Speciality
    {
        public int SpecialityId { get; set; }           // Id специальности/факультета
        public string SpecialityName { get; set; }      // Название специальности/факультета
        public string SpecialityClassifier { get; set;} //  Классификатор специальности
    }
}