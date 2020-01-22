using agos_api.Models.Base;

namespace agos_api.Models.Users
{
    public class devUser
    {
        public devUser(){}
        public devUser(ApplicationUser _user)
        {
            Id = _user.Id;
            User = _user;
        }
        public string Id { get; set; }              /// Id пользователя из группы devUser - администрация системы
        public ApplicationUser User { get; set; }   /// Ссылка на пользователя из общей таблицы пользователей
    }
}