using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Service.Interfaces;

namespace Service.Services
{
    public class EmailSender : IEmailSender
    {
        private const string Username = "tasks.noreply@gmail.com";
        private const string Password = "fiiPractic";
        
        private const string Server = "smtp.gmail.com";

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = new MailMessage(Username, email, subject, message);

            var client = new SmtpClient(Server)
            {
                Port = 587,
                Credentials = new NetworkCredential(Username, Password),
                EnableSsl = true,
            };

            return client.SendMailAsync(mail);
        }
    }
}
