using agos_api.Models.Organizations.PersonOrg;
using agos_api.Models.Studying;


namespace agos_api.Models.Organizations
{
    public class TeachDiscip 
    {
        public int TeachDiscipId { get; set; }      // Id Преподателя дисциплины
        public Discipline Discipline { get; set; }  // Ссылка на Discipline (дисциплина/предмет обучения), который преподает учитель/преподаватель
        public Teacher Teacher { get; set; }        // Ссылка на Teacher (учитель/преподаватель), который преподает выбранную дисциплину/предмет обучения
    }
}