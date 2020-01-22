namespace agos_api.Models.Organizations
{
    public class Teacher
    {
        public int TeacherId { get; set; }      /// Id учителя/преподавателя
        public string Name { get; set; }        /// Имя
        public string Surname { get; set; }     /// Фамилия
        public string Middlename { get; set; }  /// Отчество
    }
}