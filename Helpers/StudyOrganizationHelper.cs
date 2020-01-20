namespace agos_api.Helpers
{
    public class StudyOrganizationHelper
    {
        public static string KeyGenerate(int StudyOrganizationId, string ShortName, string City)
        {
            return (StudyOrganizationId).ToString() + "-" + ShortName + "-" + City;
        }
    }
}