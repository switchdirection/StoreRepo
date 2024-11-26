namespace Contracts.Users
{
    /// <summary>
    /// Транспортная модель пользователя
    /// </summary>
    public sealed class UserDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
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
        public IList<string> Roles { get; set; }
    }
}
