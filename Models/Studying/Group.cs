namespace agos_api.Models.Studying
{
    public class Group
    {
        public long GroupId { get; set; }                                           // Идентификатор
        public string GroupName { get; set; }                                       // Название группы
        public Speciality Speciality { get; set; }                                  // Ссылка на модель "Speciality"
        public short CountStudents { get; set; }                                    // Количество студентов в группе
        public short CourseNum { get; set; }                                        // Год обучения
        public string StudyLanguage { get; set; }                                   // Язык обучения
    }
}