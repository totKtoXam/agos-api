using System;

namespace agos_api.Models
{
    public class HolidayCalendar 
    {
        public int HolidayCalendarId { get; set; }      /// Id записи праздников
        public string Country { get; set; }             /// Страна в которой имеется данный праздник
        public DateTime DateHappyBegin { get; set; }    /// Начало выходных дней
        public DateTime DateHappyEnd { get; set; }      /// Конец выходных дней
        public string Name { get; set; }                /// Название праздника
    }
}