using KAShop.DAL.DTO.Request;
using KAShop.DAL.DTO.Response;
using KAShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KAShop.BLL.Service
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetAllCategories();
        Task<CategoryResponse> CreateCategory(CategoryRequest category);
        Task<CategoryResponse?> GetCategory(Expression<Func<Category, bool>> filter);
    }
}
