using agos_api.Models.StaticData;

namespace agos_api.Models
{
    public class Discipline 
    {
        public int DisciplineId { get; set; }       // Id дисциплины (предмет обучения)
        public string Name { get; set; }            // Название дисциплины (предмета обучения)
        public TypeLesson TypeLesson { get; set; }  // Ссылка на тип обучения
        public string Classifier { get; set; }      // Классификатор дисциплины (предмет обучения)
        
    }
}