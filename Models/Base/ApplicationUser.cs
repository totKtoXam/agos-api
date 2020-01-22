using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace agos_api.Models.Base
{
    #region  AppUser
        public class ApplicationUser : IdentityUser
        {
            public string Name { get; set; }        /// Имя
            public string Surname { get; set; }     /// Фамилия
            public string Middlename { get; set; }  /// Отчество
            public string FullName { get {          /// Имя и Фамилия
                return Name + " " + Surname;
            }}
        }
    #endregion

    #region RegisterViewModel
        public class RegisterViewModel              /// Модель для регистрации пользователя
        {
            [Required]
            [EmailAddress (ErrorMessage = "Некорректный адрес")]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Имя")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Фамилия")]
            public string Surname { get; set; }
            
            [Display(Name = "Отчество")]
            public string Middlename { get; set; }

            [Display(Name = "Роль")]
            public string RoleName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }

            [Required]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            [DataType(DataType.Password)]
            [Display(Name = "Подтверждение пароля")]
            public string PasswordConfirm { get; set; }

            [Required]
            [Display(Name = "Учебная организация")]
            public int studyOrganizationId { get; set; }
        }
    #endregion

    #region LogInViewModel
    public class LogInViewModel                         /// Модель для авторизации пользователя
    {
        [EmailAddress (ErrorMessage = "Некорректный адрес")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
    #endregion
}