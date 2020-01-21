namespace agos_api.Models.Organizations
{
    public class ClassroomOfTeacher 
    {
        public int ClassroomOfTeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
    }
}