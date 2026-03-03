using KAShop.BLL.Service;
using KAShop.DAL.Data;
using KAShop.DAL.DTO.Request;
using KAShop.DAL.DTO.Response;
using KAShop.DAL.Models;
using KAShop.DAL.Repository;
using KAShop.PL.Resources;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace KAShop.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       
      
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService, IStringLocalizer<SharedResources> localizer)
        {
            _categoryService = categoryService;
            _localizer = localizer;
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            var response = await _categoryService.CreateCategory(request);

            return Ok(
                new{
                _localizer["Success"].Value ,
                response
            });
        }

        [HttpGet("")]
        public async Task<ActionResult> Index()
        {
           var categories = await _categoryService.GetAllCategories();
           
            return Ok(
                new{
                  data = categories,
                _localizer["Success"].Value
            });

        }

           [HttpGet("{id}")]
           public async Task<ActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategory(c => c.Id == id);
            return Ok(category);
        }
    }

}
