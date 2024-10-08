using Application.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Repository
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        Task GetCategoryByGameId(int gameId);
        Task<List<CategoryEntity>> GetAllCategories();
    }
}
