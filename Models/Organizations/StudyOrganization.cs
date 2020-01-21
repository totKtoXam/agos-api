namespace agos_api.Models.Organizations
{
    public class StudyOrganization
    {
        public StudyOrganization(){}
        public StudyOrganization(StudyOrganization _studyOrganization)
        {
            OfficialName = _studyOrganization.OfficialName;
            ShortName = _studyOrganization.ShortName;
            AddressName = _studyOrganization.AddressName;
            NumOfHome = _studyOrganization.NumOfHome;
            City = _studyOrganization.City;
            Phone = _studyOrganization.Phone;
            Key = "noKey";
        }
        
        public int StudyOrganizationId { get; set; }
        public string OfficialName { get; set; }
        public string ShortName { get; set; }
        public string AddressName { get; set; }
        public int NumOfHome { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Key { get; set; }
    }
}