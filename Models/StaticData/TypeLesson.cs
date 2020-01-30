using System.Collections.Generic;

namespace agos_api.Models.StaticData
{
    public class TypeLesson 
    {
        public int TypeLessonId { get; set; }   // Id типа обучения

        public string TypeLessonName { get; set; }
        // public IDictionary<string, string> TypeLessonName { get; set; } = new Dictionary<string, string>();

        // public string Name { get; set; }        // Название типа обучения. Например: учебная практика, лабораторные работы, теория и т.д
    }
}