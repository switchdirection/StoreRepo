using Application.Category.Model;
using Application.Category.Services;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер категории
    /// </summary>
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Метод контроллера отображения всех категорий
        /// </summary>
        /// <param name="searchQuery">Поисковой запрос</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> ShowCategories(string searchQuery, CancellationToken cancellation)
        {
            var categoriesDto = await _categoryService.GetAllCategoriesDtoAsync(cancellation);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                categoriesDto = categoriesDto.Where(c => c.CategoryName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View("CategoriesView", categoriesDto);
        }

        /// <summary>
        /// Метод контроллера для удаления категории
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellation)
        {
            var result = await _categoryService.DeleteCategoryAsync(categoryId, cancellation);
            if (result)
            {
                TempData["DeleteCategorySuccess"] = "Категория успешно удалена";
            }
            else
            {
                TempData["DeletedCategoryError"] = "Категория не была удалена";
            }
            return RedirectToAction("ShowCategories");
        }
        /// <summary>
        /// Метод контроллера для изменения категории
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditCategory(EditCategoryModel model, CancellationToken cancellation)
        {
            var result = await _categoryService.EditCategoryAsync(model, cancellation);
            if(result)
            {
                TempData["EditCategorySuccess"] = "Категория была успешно отредактирована";
            }
            else
            {
                TempData["EditCategoryError"] = "Категория не была отредактирована";
            }
            return RedirectToAction("ShowCategories");
        }
        /// <summary>
        /// Метод контроллера для добавления новой категории
        /// </summary>
        /// <param name="request">Запрос на добавления категории</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryRequest request, CancellationToken cancellation)
        {
            var result = await _categoryService.AddCategoryAsync(request.categoryName, cancellation);
            if (result)
            {
                TempData["AddCategorySuccess"] = "Категория добавлена успешно";
            }
            else
            {
                TempData["AddCategoryError"] = "Категория не была добавленна";
            }

            return RedirectToAction("ShowCategories");
        }
    }
}
