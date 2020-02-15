using agos_api.Models.Organizations.PersonOrg;

namespace agos_api.Models.Organizations
{
    public class ClassroomOfTeacher 
    {
        public int ClassroomOfTeacherId { get; set; }   // Id аудитории/кабинет закрепленный под преподавателя/учителя
        public Teacher Teacher { get; set; }            // Ссылка на преподавателя/учителя
        public string Classroom { get; set; }        // Ссылка на Classroom - аудитория/кабинет
        public StudyOrganization StudyOrganization { get; set; }
    }

    public class ClassroomOfTeacherViewModel : ClassroomOfTeacher
    {
        public bool ConfirmIsInsertData { get; set; }   //// На случай, если аудитория/кабинет уже привязан к преподавателю
                                                        //// для подтверждения пользователя к привязке 
    }
}