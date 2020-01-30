using System;
using System.ComponentModel.DataAnnotations;

namespace agos_api.Models.Organizations
{
    public class RepresentativeOrganization
    {
        [Key]
        public Guid ReprId { get; set; }        // Id представителя учебной организации
        public string Name { get; set; }        // Имя
        public string SurName { get; set; }     // Фамилия
        public string MiddleName { get; set; }  // Отчество
        public string MobilePhone { get; set; } // Мобильные номер телефона
        public string PositionWork { get; set; }// Должность представителя в учебной организации
        public string Email { get; set; }       // Эл. почта
    }
}