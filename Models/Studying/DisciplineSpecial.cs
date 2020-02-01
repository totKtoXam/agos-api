namespace agos_api.Models.Studying
{
    public class DisciplineSpecial 
    {
        public int DisciplineSpecialId { get; set; }        // Id Дисциплин специальности
        public ClassificationSpeciality ClassificationSpeciality { get; set;} // Ссылка на ClassificationSpeciality
        public Discipline Discipline { get; set; }          // Ссылка на дисциплину (предмет обучения)

    }
}