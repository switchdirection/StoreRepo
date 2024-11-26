using Domain.Entities;
using System.Net.Mail;
using System.Net;
using Contracts.Requests;

namespace Application.Email.Service
{
    /// <summary>
    /// Сервис по работе с электронной почтой
    /// </summary>
    public sealed class EmailService : IEmailService
    {
        /// <inheritdoc/>
        public void SendEmail(string subject, string body, ApplicationUser user)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "gordon-play@bk.ru";
            string smtpPassword = "zyXyyMDmaYLL1wM6Sz7B";

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(user.Email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    try
                    {
                        smtpClient.Send(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
        }

        /// <inheritdoc/>
        public void SendMailToBuyer(AddOrderRequest request, ApplicationUser user)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "gordon-play@bk.ru";
            string smtpPassword = "zyXyyMDmaYLL1wM6Sz7B";

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(user.Email);
                    mailMessage.Subject = "Товар успешно добавлен в обработку!";
                    mailMessage.Body = $"{request.userLastname} {request.userName} {request.userSurname} благодарим вас за покупку в нашем онлайн магазине!\nSteamMarket Team! <3";

                    try
                    {
                        smtpClient.Send(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
        }
    }
}
