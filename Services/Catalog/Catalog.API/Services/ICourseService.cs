using Catalog.API.Dtos;
using FreeCourse.Shared.Dtos;

namespace Catalog.API.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string UserId);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto course);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto updateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
