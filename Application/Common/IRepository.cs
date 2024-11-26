namespace Application.Common
{
    /// <summary>
    /// Интерфейс общего репозитория
    /// </summary>
    /// <typeparam name="T">Тип сущности к которой будет пренадлежать репозиторий</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получить все сущности из таблицы
        /// </summary>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Получить сущность из таблицы по Id
        /// </summary>
        /// <param name="id"></param>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Добавить сущность в таблицу
        /// </summary>
        /// <param name="entity">Сущность которую хотите добавить</param>
        /// <returns></returns>
        Task AddAsync(T entity);
    }
}
