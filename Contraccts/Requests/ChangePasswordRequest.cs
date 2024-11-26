namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на смену пароля
    /// </summary>
    public sealed class ChangePasswordRequest
    {
        /// <summary>
        /// Текущий пароль
        /// </summary>
        public string currentPassword { get; set; }
        /// <summary>
        /// Новый пароль
        /// </summary>
        public string newPassword { get; set; }
    }
}
