using Discount.API.Models;
using FreeCourse.Shared.Dtos;

namespace Discount.API.Services
{
    public interface IDiscountService
    {
        Task<Response<List<Models.Discount>>> GetAll();
        Task<Response<Models.Discount>> GetById(string id);
        Task<Response<NoContent>> Save(Models.Discount discount);
        Task<Response<NoContent>> Update(Models.Discount discount);
        Task<Response<NoContent>> DeleteById(int Id);
        Task<Response<Models.Discount>> GetByCodeAndUserId(string code , string userId);
    }
}
