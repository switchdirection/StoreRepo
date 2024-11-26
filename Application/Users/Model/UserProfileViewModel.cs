using Application.Orders.Model;

namespace Application.Users.Model
{
    /// <summary>
    /// Модель пользователя для отображения в личном кабинете
    /// </summary>
    public class UserProfileViewModel
    {
        /// <summary>
        /// Имя 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Список заказов пользователя
        /// </summary>
        public List<OrderViewModel> Orders { get; set; }
    }
}
