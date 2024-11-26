using Contracts.Common;
using Application.Games.Filters;

namespace Application.Games.Model
{
    /// <summary>
    /// Модель для отображения игр
    /// </summary>
    public sealed class GameViewModel
    {
        /// <summary>
        /// Игры
        /// </summary>
        public ShortGameEntityList Games { get; set; } 
        /// <summary>
        /// Фильтр
        /// </summary>
        public GameFilters Filters { get; set; } 
    }
}
