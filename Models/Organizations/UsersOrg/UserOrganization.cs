using agos_api.Models.Base;
using agos_api.Models.Organizations;

namespace agos_api.Models.UsersOrg
{
    public class UserOrganization
    {
        public UserOrganization(){}
        public UserOrganization(ApplicationUser _user, StudyOrganization _studyOrganization)
        {
            Id = _user.Id;
            User = _user;
            studyOrganization = _studyOrganization;
        }

        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public StudyOrganization studyOrganization { get; set; }
    }
}