using Catalog.API.Dtos;
using Catalog.API.Models;
using FreeCourse.Shared.Dtos;

namespace Catalog.API.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        Task<Response<CategoryDto>> GeyByIdAsync(string id);
    }
}
