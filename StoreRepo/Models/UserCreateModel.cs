using System.ComponentModel.DataAnnotations;

namespace StoreRepo.Models
{
    /// <summary>
    /// Модель для создания пользователя
    /// </summary>
    public sealed class UserCreateModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
