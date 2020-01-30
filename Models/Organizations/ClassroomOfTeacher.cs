using agos_api.Models.Organizations.PersonOrg;

namespace agos_api.Models.Organizations
{
    public class ClassroomOfTeacher 
    {
        public int ClassroomOfTeacherId { get; set; }   // Id аудитории/кабинет закрепленный под преподавателя/учителя
        public Teacher Teacher { get; set; }            // Ссылка на преподавателя/учителя
        public Classroom Classroom { get; set; }        // Ссылка на Classrom - аудитория/кабинет
    }
}