using System;

namespace agos_api.Models
{
    public class HolidayCalendar 
    {
        public int HolidayCalendarId { get; set; }
        public string Country { get; set; }
        public DateTime DateHappyBegin { get; set; }
        public DateTime DateHappyEnd { get; set; } 
        public string Name { get; set; }
    }
}