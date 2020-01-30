using System.ComponentModel.DataAnnotations;

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
        
        public StudyOrganization(int studyOrganizationId, string officialName, string shortName, string addressName, int numOfHome, string city, string phone, string key) 
        {
            this.StudyOrganizationId = studyOrganizationId;
                this.OfficialName = officialName;
                this.ShortName = shortName;
                this.AddressName = addressName;
                this.NumOfHome = numOfHome;
                this.City = city;
                this.Phone = phone;
                this.Key = key;
               
        }
        [Key]
        public int StudyOrganizationId { get; set; }    // Id учебной организации
        public string OfficialName { get; set; }        // Официальное название учебной организации
        public string ShortName { get; set; }           // Короткое название учебной организации (аббревиатура)
        public string AddressName { get; set; }         // Наименование адреса расположения учебной организации
        public int NumOfHome { get; set; }              // Номер дома учебной организации
        public string City { get; set; }                // Город в котором находится учебная организация
        public string Phone { get; set; }               // Городской номер учебной организации
    
        #nullable enable
        public RepresentativeOrganization? RepresentativeOrganization { get; set; }  //  Ссылка на представителя учебной организации
        #nullable enable
        public string? Key { get; set; }                 // Ключ учебной организации для получения доступа к определенынм информациям
    }
}