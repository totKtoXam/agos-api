namespace agos_api.Models.Studying
{
    public class DisciplineSpecial 
    {
        public int DisciplineSpecialId { get; set; }        // Id Дисциплин специальности
        public SpecialityOtdel SpecialityOtdel { get; set;} // Ссылка на специальности
        public Discipline Discipline { get; set; }          // Ссылка на дисциплину (предмет обучения)

    }
}