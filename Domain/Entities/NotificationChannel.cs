namespace Domain.Entities
{
    /// <summary>
    /// Способы оповещения пользователя
    /// </summary>
    public class NotificationChannel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
}
