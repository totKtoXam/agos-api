using agos_api.Services;
using agos_api.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using agos_api.Models.Email;

namespace agos_api.Helpers
{
    public interface IEmailHelper
    {
        Task<bool> SendEmailConfirmAsync (ApplicationUser userModel, string callbackUrl);
    }
    public class EmailHelper : IEmailHelper
    { 
        public readonly IEmailServices _emailService;
        private readonly UserManager<ApplicationUser> _userManager;

         public EmailHelper(IEmailServices emailService, UserManager<ApplicationUser> userManager)
        {
            _emailService = emailService;
            _userManager = userManager;
        }

        public async Task<bool> SendEmailConfirmAsync (ApplicationUser userModel, string callbackUrl)
        {
            EmailSendViewModel sendModel = new EmailSendViewModel()
            {
                EmailRecipient = userModel.Email,
                FullnameSubject = userModel.FullName,
                Link = callbackUrl,
                MessageText = string.Format(@"Чтобы завершить регистрацию Вам необходимо перейти по ссылке для подтверждения Вашей электронной почты"),
                MessageTitle = string.Format($"Здравствуйте, {userModel.FullName}!")
            };
            var sendResult = await _emailService.SendEmailAsync(sendModel);
            return sendResult;
        }
    }
}