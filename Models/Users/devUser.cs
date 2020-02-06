using agos_api.Models.Base;

namespace agos_api.Models.Users
{
    public class DevUser
    {
        public DevUser(){}
        public DevUser(ApplicationUser _user)
        {
            Id = _user.Id;
            User = _user;
        }
        public string Id { get; set; }              // Id пользователя из группы DevUser - администрация системы
        public ApplicationUser User { get; set; }   // Ссылка на пользователя из общей таблицы пользователей
    }
}