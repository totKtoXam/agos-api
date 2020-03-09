using System.Collections.Generic;
using agos_api.Models.StaticData;

namespace agos_api.Models.Studying
{
    public class Discipline 
    {
        public int DisciplineId { get; set; }       // Id дисциплины (предмет обучения)
        public string Name { get; set; }            // Название дисциплины (предмета обучения)
        public string Classifier { get; set; }      // Классификатор дисциплины (предмет обучения)
        public TypeLesson TypeLesson { get; set; }  // Ссылка на тип обучения
        
    }

    public class DisciplineSpecialityViewModel : Discipline
    {
        public List<int?> ClassificationIdList { get; set; }
    }
}