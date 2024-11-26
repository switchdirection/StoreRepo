namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на сброс пароля
    /// </summary>
    public sealed class PasswordResetRequest
    {
        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Электронная почта для отправки кода
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Код сброса
        /// </summary>
        public string ResetCode { get; set; }
        /// <summary>
        /// Время жизни запроса
        /// </summary>
        public DateTime ExpirationTime { get; set; }
    }
}
