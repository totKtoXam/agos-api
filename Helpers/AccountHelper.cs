using System.Text.RegularExpressions;

namespace agos_api.Helpers
{
    public class AccountHelper
    {
        public static bool IsValidPassword (string password)
        {
            Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$");
            Match match = regex.Match(password);
            return match.Success;
        }
    }
}