using Microsoft.AspNetCore.Identity;

namespace agos_api.Models.Base
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Language { get; set; } //kz, en, ru
        public string FullName { get {
            return Name + " " + Surname;
        }}
    }
}