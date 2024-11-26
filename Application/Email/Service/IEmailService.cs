using Contracts.Requests;
using Domain.Entities;

namespace Application.Email.Service
{
    /// <summary>
    /// Интерфейс сервиса по работе с электронной почтой
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Метод для отправки email подтверждения заказа
        /// </summary>
        /// <param name="request">Запрос на добавление заказа</param>
        /// <param name="user">Пользователь который оформил заказ</param>
        void SendMailToBuyer(AddOrderRequest request, ApplicationUser user);
        /// <summary>
        /// Метод для отправки email пользователю
        /// </summary>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="body">Текст сообщения</param>
        /// <param name="user">Пользователь которому нужно отправить сообщения</param>
        void SendEmail(string subject, string body, ApplicationUser user);
    }
}
