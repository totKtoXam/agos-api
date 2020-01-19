using agos_api.Models.Base;

namespace agos_api.Models.UsersOrg
{
    public class UserOrganization
    {
        public UserOrganization(){}
        public UserOrganization(ApplicationUser _user)
        {
            Id = _user.Id;
            User = _user;
        }

        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        // public StudyOrganization studyOrganization { get; set; }
    }
}