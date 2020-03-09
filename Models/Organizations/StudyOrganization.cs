using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using agos_api.Models.Organizations.PersonOrg;

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
            BIN = _studyOrganization.BIN;
            Key = "noKey";
            SignDate = (_studyOrganization.SignDate == DateTime.MinValue) ? DateTime.Now : _studyOrganization.SignDate;
        }
        
        // public StudyOrganization(int studyOrganizationId, string officialName, string shortName, string addressName, int numOfHome, string city, string phone, string key, string BIN) 
        // {
        //     this.StudyOrganizationId = studyOrganizationId;
        //     this.OfficialName = officialName;
        //     this.ShortName = shortName;
        //     this.AddressName = addressName;
        //     this.NumOfHome = numOfHome;
        //     this.City = city;
        //     this.Phone = phone;
        //     this.Key = key;
        //     this.BIN = BIN;
        //     this.SignDate = (SignDate == DateTime.MinValue) ? DateTime.Now : SignDate;
        // }
        [Key]
        public int StudyOrganizationId { get; set; }    // Id учебной организации
        public string OfficialName { get; set; }        // Официальное название учебной организации
        public string ShortName { get; set; }           // Короткое название учебной организации (аббревиатура)
        public string AddressName { get; set; }         // Наименование адреса расположения учебной организации
        public int NumOfHome { get; set; }              // Номер дома учебной организации
        public string City { get; set; }                // Город в котором находится учебная организация
        public string Phone { get; set; }               // Городской номер учебной организации
        [StringLength(12, ErrorMessage="Количество символов в БИН равно 12")]
        public string BIN { get; set; }                 // БИН - Бизнес-Идентификационный Номер
    
#nullable enable
        public string? Key { get; set; }                 // Ключ учебной организации для получения доступа к определенынм информациям
#nullable disable
        public DateTime SignDate { get; set; }
        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; set; }
    }
}