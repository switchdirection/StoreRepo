using System.ComponentModel.DataAnnotations;

namespace StoreRepo.Models
{
    /// <summary>
    /// Модель для входа пользователя
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// Запомнить меня
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
