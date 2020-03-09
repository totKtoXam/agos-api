namespace agos_api.Models.Studying
{
    public class DisciplineClassific 
    {
        public int DisciplineClassificId { get; set; }        // Id Дисциплин специальности
        public Classification Classification { get; set;}   // Ссылка на Classification
        public Discipline Discipline { get; set; }          // Ссылка на дисциплину (предмет обучения)

    }
}