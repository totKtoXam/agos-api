using System.ComponentModel.DataAnnotations;
using agos_api.Models.Base;

namespace agos_api.Models.Users
{
    public class DevUser
    {
        public DevUser(){}
        public DevUser(ApplicationUser _user)
        {
            DevUserId = _user.Id;
        }
        [Key]
        public string DevUserId { get; set; }
        // public ApplicationUser User { get; set; }   // Ссылка на пользователя из общей таблицы пользователей
        public string IIN { get; set; }
        public string Position { get; set; }
    }
}