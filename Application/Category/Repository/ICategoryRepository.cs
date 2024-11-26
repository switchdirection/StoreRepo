using Application.Category.Model;
using Application.Common;
using Domain.Entities;

namespace Application.Category.Repository
{
    /// <summary>
    /// Интерфейс репозитория по работе с категориями
    /// </summary>
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        /// <summary>
        /// Метод для получения всех категорий
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод получения категории по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<CategoryEntity> GetCategoryByIdAsync(int id, CancellationToken cancellation);
		/// <summary>
        /// Метод для добавления категории
        /// </summary>
        /// <param name="category">Сущность категории</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> AddCategoryAsync(CategoryEntity category, CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления категории
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> DeleteCategoryAsync(int categoryId, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования категории
        /// </summary>
        /// <param name="model">Модель редактирования категории</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> EditCategoryAsync(EditCategoryModel model, CancellationToken cancellation);
    }
}
