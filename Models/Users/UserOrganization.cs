using agos_api.Models.Base;
using agos_api.Models.Organizations;

namespace agos_api.Models.Users
{
    public class UserOrganization
    {
        public UserOrganization(){}

        public UserOrganization(ApplicationUser orgAdminUser)
        {
            this.User = orgAdminUser;
        }

        public UserOrganization(ApplicationUser _user, StudyOrganization _studyOrganization)    // Контруктор класс
        {
            Id = _user.Id;
            User = _user;
            StudyOrganization = _studyOrganization;
        }

        public string Id { get; set; }                          // Id
        public ApplicationUser User { get; set; }               // Ссылка на пользователя из общей таблицы пользователей
        public StudyOrganization StudyOrganization { get; set; }// Ссылка на учебную организацию
    }
}