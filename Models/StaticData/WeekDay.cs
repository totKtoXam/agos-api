using System;
using System.Collections.Generic;

namespace agos_api.Models.StaticData
{
    public class WeekDay
    {
        public int id { get; set; }         // Id дня недели
        public string DayFullName { get; set; }
        public string DayShortName { get; set; }
        // public IDictionary<string, string> FullDayName { get; set; } = new Dictionary<string, string>();
        // public IDictionary<string, string> ShortDayName { get; set; } = new Dictionary<string, string>();

        // public string DayNameKz { get; set; } // Название дня недели
        // public string DayNameRu { get; set; } // Название дня недели
        // public string DayNameEn { get; set; } // Название дня недели
    }
}