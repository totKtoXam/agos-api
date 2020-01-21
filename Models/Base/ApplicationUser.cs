using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace agos_api.Models.Base
{
    #region  AppUser
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

    #region RegisterViewModel
        public class RegisterViewModel
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
    public class LogInViewModel
    {
        [EmailAddress (ErrorMessage = "Некорректный адрес")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
    #endregion

    #region JwtToken
        public class RefreshToken
        {
            public RefreshToken(){}
            public RefreshToken(string _id){ Id = _id; }
            public string Id { get; set; } // = AppUser.Id
            public string Token { get; set; }
            public bool Revoked { get; set; }
            public DateTime StartDate { get; set; } // = CreatedDate
            public DateTime FinishDate { get; set; } // = ExpireDate
        }
    #endregion
}