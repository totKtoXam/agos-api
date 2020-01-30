using System.Collections.Generic;

namespace agos_api.Models.StaticData
{
    public class TypeWeek 
    {
        public int TypeWeekId { get; set; }         // Id типа недели

        public string TypeWeekName { get; set; }
        // public IDictionary<string, string> TypeWeekName { get; set; } = new Dictionary<string, string>();

        // public string TypeWeekNameKz { get; set; }    // Название типа недели на казахском  (есептегіш, анықтауыш)
        // public string TypeWeekNameRu { get; set; }    // Название типа недели на русском    (числитель, знаминатель)
        // public string TypeWeekNameEn { get; set; }    // Название типа недели на английском (numerator, denominator)
    }
}