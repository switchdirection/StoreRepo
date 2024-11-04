using System.ComponentModel.DataAnnotations;

namespace StoreRepo.Models
{
    /// <summary>
    /// Модель для регистрации пользователя
    /// </summary>
    public class RegisterViewModel
    {
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
        /// Пароль для подтверждения
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Список ошибок
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
