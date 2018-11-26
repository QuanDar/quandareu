using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using quaneu.webapi.ViewModels;

namespace quaneu.webapi.Services
{
    public class MailService
    {
        // POST api/<mail>
        public static async Task PostEmail(MailViewModel mail, IConfiguration configuration)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = configuration["Email:Email"],
                    Password = configuration["Email:Password"]
                };

                client.Credentials = credential;
                client.Host = configuration["Email:Host"];
                client.Port = int.Parse(configuration["Email:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(configuration["Email:Email"]));
                    emailMessage.From = new MailAddress(configuration["Email:Email"]);
                    emailMessage.Subject = mail.Subject;
                    emailMessage.Body = mail.Body +
                        Environment.NewLine +
                        Environment.NewLine +
                        "From: " + mail.From +
                        Environment.NewLine +
                        "Postal Code: " + mail.ZipCode +
                        Environment.NewLine +
                        "Local Community: " + mail.LocalCommunity;
                    client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
        }
    }
}
