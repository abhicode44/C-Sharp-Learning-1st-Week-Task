using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Options;
using static System.Net.WebRequestMethods;

namespace Bank_Application.Helper
{
    public class EmailServices : IEmailServices
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailServices(IOptions<SmtpSettings> smtpOptions)
        {
            _smtpSettings = smtpOptions.Value;
        }
        public  async Task SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var message = new MailMessage(_smtpSettings.UserName, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                using var smtp = new SmtpClient(_smtpSettings.Host)
                {
                    Port = _smtpSettings.Port,
                    Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password),
                    EnableSsl = _smtpSettings.EnableSsl
                };

                await smtp.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EMAIL ERROR] {ex}");
                throw;
            }
        }
    }


}
    

