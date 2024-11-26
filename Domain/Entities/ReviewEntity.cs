namespace Domain.Entities
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public sealed class ReviewEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ReviewId { get; set; }
        /// <summary>
        /// Пользователь оставивший отзыв
        /// </summary>
        public ApplicationUser? UserId { get; set; }
        /// <summary>
        /// Игра на которую оставили отзыв
        /// </summary>
        public GameEntity? GameId { get; set; }
        /// <summary>
        /// Рейтинг выставленный пользователем
        /// </summary>
        public int Rating { get; set; } = 0;
        /// <summary>
        /// Текст отзыва
        /// </summary>
        public string? ReviewText { get; set; } = default!;
        /// <summary>
        /// Дата написания отзыва
        /// </summary>
        public DateTime ReviewDate { get; set; } = default!;
    }
}
