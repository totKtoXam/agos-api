namespace agos_api.Models.Studying
{
    public class DisciplineSpecial 
    {
        public int DisciplineSpecialId { get; set; }        // Id Дисциплин специальности
        public Speciality Speciality { get; set;}           // Ссылка на Speciality
        public Discipline Discipline { get; set; }          // Ссылка на дисциплину (предмет обучения)

    }
}