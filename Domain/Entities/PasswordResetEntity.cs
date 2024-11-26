namespace Domain.Entities
{
    /// <summary>
    /// Сущность сброса пароля
    /// </summary>
    public sealed class PasswordResetEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Email для которого запрошен сброс
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Код отправленный на email для сброса пароля
        /// </summary>
        public string ResetCode { get; set; }
        /// <summary>
        /// Время запроса
        /// </summary>
        public DateTime ExpirationTime { get; set; }
    }
}
