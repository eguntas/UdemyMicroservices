using Catalog.API.Dtos;
using Catalog.API.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(categories);  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GeyByIdAsync(id);
            return CreateActionResultInstance(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            var result =await _categoryService.CreateAsync(dto);
            return CreateActionResultInstance(result);  

        }
    }
}
