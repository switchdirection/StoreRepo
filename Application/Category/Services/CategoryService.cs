using Application.Category.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Services
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<List<CategoryEntity>> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Task GetCategoryByGameId(int id)
        {
            return _categoryRepository.GetCategoryByGameId(id);
        }


    }
}
