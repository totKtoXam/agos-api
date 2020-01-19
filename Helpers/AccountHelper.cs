using System.Text.RegularExpressions;

namespace agos_api.Helpers
{
    public class AccountHelper
    {
        public static bool IsValidPassword (string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{1,16}$");
            Match match = regex.Match(password);
            return match.Success;
        }
    }
}