namespace Domain.Entities
{
    /// <summary>
    /// Корзина
    /// </summary>
    public sealed class CartEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор пользователя кому принадлежит корзина
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public ApplicationUser User { get; set; }
        /// <summary>
        /// Игры добавленные в корзину
        /// </summary>
        public List<GameEntity> Games { get; set; } = new List<GameEntity>();
    }
}
