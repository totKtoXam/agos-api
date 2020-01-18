namespace agos_api.Models
{
    public class StudyOrganization
    {
        public int StudyOrganizationId { get; set; }
        public string OfficialName { get; set; }
        public string ShortName { get; set; }
        public string AddressName { get; set; }
        public int NumOfHome { get; set; }
        public string City { get; set; }
        public string Key { get; set; }
    }
}