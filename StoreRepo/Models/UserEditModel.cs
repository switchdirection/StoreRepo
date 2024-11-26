namespace StoreRepo.Models
{
    /// <summary>
    /// Модель редактирования пользователя
    /// </summary>
    public sealed class UserEditModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
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
        /// Роли
        /// </summary>
        public List<string> Roles { get; set; }
    }
}
