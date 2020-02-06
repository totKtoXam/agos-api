using System;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using agos_api.Models.Email;

namespace agos_api.Services
{
    public interface IEmailServices
    {
        Task<bool> SendEmailAsync(EmailSendViewModel model);
    }


    public class EmailServices : IEmailServices
    {
        public async Task<bool> SendEmailAsync(EmailSendViewModel model)
        {
            var emailMessage = new MimeMessage();

            // E-mail of sender
            emailMessage.From.Add(new MailboxAddress("Администрация сайта AGoS", "agos.vb@yandex.kz"));

            // E-mail of recipient
            emailMessage.To.Add(new MailboxAddress("", model.EmailRecipient));
            if (String.IsNullOrEmpty(model.FullnameSubject))
                model.FullnameSubject = model.EmailRecipient;

            // Fullname or UserName of recipient
            emailMessage.Subject = model.FullnameSubject;

            // Body for message
            StringBuilder sbMessageBody = new StringBuilder();
            BodyBuilder bodyBuilder = new BodyBuilder();

            if (!string.IsNullOrEmpty(model.MessageTitle))
                sbMessageBody.Append($"<h3>Здравствуйте, {model.FullnameSubject} !</h3>\r\n");
            if (!string.IsNullOrEmpty(model.MessageText))
                sbMessageBody.Append($"\r\n{model.MessageText}\r\n");
            if (!string.IsNullOrEmpty(model.Link))
                sbMessageBody.Append($"\r\n<a href={model.Link}>Нажмите, чтобы перейти по ссылке.</a>");

            bodyBuilder.HtmlBody = Convert.ToString(sbMessageBody);
            emailMessage.Body = bodyBuilder.ToMessageBody();

            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.yandex.ru", 25, false);
                    await client.AuthenticateAsync("agos.vb@yandex.kz", "Pvq-Ln5-6pq-q55");
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}