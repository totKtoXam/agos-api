using agos_api.Models.StaticData;

namespace agos_api.Models
{
    public class Discipline 
    {
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public TypeLesson TypeLesson { get; set; }
        public string Classifier { get; set; }
        
    }
}