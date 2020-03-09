namespace agos_api.Models.Organizations.PersonOrg
{
    public class Teacher
    {
        public int TeacherId { get; set; }      // Id учителя/преподавателя
        public string LastName { get; set; }        // Имя
        public string FirstName { get; set; }     // Фамилия
        public string Middlename { get; set; }  // Отчество
        public StudyOrganization StudyOrganization { get; set; }  //  Ссылка на представителя учебной организации
    }
}