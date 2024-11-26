using Application.Category.Model;
using Contracts.Games;
using Domain.Entities;

namespace Application.Category.Services
{
    /// <summary>
    /// Интерфейс сервиса по работе с категориями
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Метод для получения всех категорий
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для получения категории по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<CategoryEntity> GetCategoryByIdAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод добавления категории
        /// </summary>
        /// <param name="categoryName">Название категории</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> AddCategoryAsync(string categoryName, CancellationToken cancellation); 
        /// <summary>
        /// Получить список всех категории в транспортной модели
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<CategoryListDto>> GetAllCategoriesDtoAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления категорию
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> DeleteCategoryAsync(int categoryId,  CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования категории
        /// </summary>
        /// <param name="model">Модель для редактирования категории</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task<bool> EditCategoryAsync(EditCategoryModel model, CancellationToken cancellation);
	}
}
