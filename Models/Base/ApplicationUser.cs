using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace agos_api.Models.Base
{
    #region  App User
        public class ApplicationUser : IdentityUser
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Middlename { get; set; }
            public string Language { get; set; } //kz, en, ru
            public string FullName { get {
                return Name + " " + Surname;
            }}
        }
    #endregion

    #region Register View Model
        public class RegisterViewModel
        {
            [Required]
            [Display(Name = "E-mail")]
            public string email { get; set; }

            [Required]
            [Display(Name = "Имя")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Фамилия")]
            public string Surname { get; set; }
            
            [Display(Name = "Отчество")]
            public string Middlename { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }

            [Required]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            [DataType(DataType.Password)]
            [Display(Name = "Подтверждение пароля")]
            public string PasswordConfirm { get; set; }

            // [Required]
            // [Display("Учебная организация")]
            // public
        }
    #endregion
}