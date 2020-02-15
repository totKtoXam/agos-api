namespace agos_api.Models.Organizations.PersonOrg
{
    public class Teacher
    {
        public int TeacherId { get; set; }      // Id учителя/преподавателя
        public string Name { get; set; }        // Имя
        public string Surname { get; set; }     // Фамилия
        public string Middlename { get; set; }  // Отчество
        public RepresentativeOrganization RepresentativeOrganization { get; set; }  //  Ссылка на представителя учебной организации
    }
}