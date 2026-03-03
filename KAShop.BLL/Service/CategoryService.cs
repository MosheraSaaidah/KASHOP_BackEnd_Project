using KAShop.DAL.DTO.Request;
using KAShop.DAL.DTO.Response;
using KAShop.DAL.Models;
using KAShop.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAShop.BLL.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) { 
        _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse> CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
         await   _categoryRepository.CreateAsync(category);

            return category.Adapt<CategoryResponse>();      
        }

        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return  categories.Adapt<List<CategoryResponse>>();
        }
    }
}
