using System.Text.RegularExpressions;

namespace agos_api.Helpers
{
    public class AccountHelper
    {
        public static bool IsValidPassword (string password)
        {
            Match check1, check2, check3, check4;
            Regex regex = new Regex(@"([A-Z]+)");
            check1 = regex.Match(password);
            regex = new Regex(@"([a-z]+)");
            check2 = regex.Match(password);
            regex = new Regex(@"([0-9]+)");
            check3 = regex.Match(password);
            regex = new Regex(@"([@#$%]+)");
            check4 = regex.Match(password);

            bool isValidPass = false;
            if ((check4.Success) && (check2.Success) && (check3.Success) && (check4.Success) && ((password.Length > 6) && (password.Length <= 255)))
            {
                isValidPass = true;
            }
            return isValidPass;
        }
    }
}