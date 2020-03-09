using System;
using agos_api.Models.Organizations;

namespace agos_api.Models
{
    public class HolidayCalendar 
    {
        public int HolidayCalendarId { get; set; }      // Id записи праздников
        public string Country { get; set; }             // Страна в которой имеется данный праздник
        public DateTime DateHappyBegin { get; set; }    // Начало выходных дней
        public DateTime DateHappyEnd { get; set; }      // Конец выходных дней
        public string Name { get; set; }                // Название праздника
        public bool GosHoliday { get; set; }            // Гос. праздник.
        //// Если GosHoliday == true, то StudyOrganization = null, иначе необходимо указать ссылку к организации - StudyOrganization
#nullable enable
        public StudyOrganization? StudyOrganization { get; set; }
#nullable disable
    }
}