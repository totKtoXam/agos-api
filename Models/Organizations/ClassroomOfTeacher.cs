using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using agos_api.Models.Organizations.PersonOrg;

namespace agos_api.Models.Organizations
{
    public class ClassroomOfTeacher 
    {
        public int ClassroomOfTeacherId { get; set; }           // Id аудитории/кабинет закрепленный под преподавателя/учителя
        public Teacher Teacher { get; set; }                    // Ссылка на преподавателя/учителя
        public List<Classroom> Classrooms { get; set; }
        public StudyOrganization StudyOrganization { get; set; }// Ссылка на учебную организацию
    }

    [NotMapped]
    public class Classroom
    {
        public string ClassroomNumber { get; set; }     // Номер аудитории/кабинета
        public string ClassroomFloor { get; set; }      // Этаж на котором находится аудитория/кабинет
    }

    public class ClassroomOfTeacherViewModel : ClassroomOfTeacher
    {
        public bool ConfirmIsInsertData { get; set; }   //// На случай, если аудитория/кабинет уже привязан к преподавателю
                                                        //// для подтверждения пользователя к привязке 
    }
}