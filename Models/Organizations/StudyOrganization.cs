namespace agos_api.Models.Organizations
{
    public class StudyOrganization
    {
        public StudyOrganization(){}
        public StudyOrganization(StudyOrganization _studyOrganization)  // Конструктор класса
        {
            OfficialName = _studyOrganization.OfficialName;
            ShortName = _studyOrganization.ShortName;
            AddressName = _studyOrganization.AddressName;
            NumOfHome = _studyOrganization.NumOfHome;
            City = _studyOrganization.City;
            Phone = _studyOrganization.Phone;
            Key = "noKey";
        }
        
        public int StudyOrganizationId { get; set; }    // Id учебной организации
        public string OfficialName { get; set; }        // Официальное название учебной организации
        public string ShortName { get; set; }           // Короткое название учебной организации (аббревиатура)
        public string AddressName { get; set; }         // Наименование адреса расположения учебной организации
        public int NumOfHome { get; set; }              // Номер дома учебной организации
        public string City { get; set; }                // Город в котором находится учебная организация
        public string Phone { get; set; }               // Городской номер учебной организации
        // public RepresentativeOrganization RepresentativeOrganization { get; set; }  //  Ссылка на представителя учебной организации
        public string Key { get; set; }                 // Ключ учебной организации для получения доступа к определенынм информациям
    }
}