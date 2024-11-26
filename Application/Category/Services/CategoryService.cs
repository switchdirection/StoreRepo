using Application.Category.Model;
using Application.Category.Repository;
using AutoMapper;
using Contracts.Games;
using Domain.Entities;

namespace Application.Category.Services
{
    /// <summary>
    /// Сервис по работе с категориями
    /// </summary>
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<bool> AddCategoryAsync(string categoryName, CancellationToken cancellation)
        {
            try
            {
                return await _categoryRepository.AddCategoryAsync(new CategoryEntity
                {
                    CategoryName = categoryName
                }, cancellation);
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteCategoryAsync(int categoryId, CancellationToken cancellation)
        {
            try
            {
                return await _categoryRepository.DeleteCategoryAsync(categoryId, cancellation);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> EditCategoryAsync(EditCategoryModel model, CancellationToken cancellation)
        {
            try
            {
                await _categoryRepository.EditCategoryAsync(model, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public Task<List<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellation)
        {
            return _categoryRepository.GetAllCategoriesAsync(cancellation);
        }

        /// <inheritdoc/>
		public async Task<List<CategoryListDto>> GetAllCategoriesDtoAsync(CancellationToken cancellation)
		{
			var categories =  await _categoryRepository.GetAllCategoriesAsync(cancellation);
            var categoriesDto = _mapper.Map<List<CategoryListDto>>(categories);
            return categoriesDto;
		}

        /// <inheritdoc/>
        public async Task<CategoryEntity> GetCategoryByIdAsync(int id, CancellationToken cancellation)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id, cancellation);
        }
    }
}
