using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Services
{
    public interface ICategoryService
    {
        Task GetCategoryByGameId(int id);
        Task<List<CategoryEntity>> GetAllCategories();
        Task<CategoryEntity> GetCategoryById(int id);
    }
}
