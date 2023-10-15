using Discount.API.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared3._1.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountController(IDiscountService discountService, ISharedIdentityService sharedIdentityService)
        {
            _discountService = discountService;
            _sharedIdentityService = sharedIdentityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _discountService.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(string Id)
        {
            return CreateActionResultInstance(await _discountService.GetById(Id));
        }
        [Route("api/[controller]/[action]/{code}")]
        [HttpGet]
        public async Task<IActionResult> GetUserIdAndCode(string code)
        {
            var userId = _sharedIdentityService.GetUserId;
            return CreateActionResultInstance(await _discountService.GetByCodeAndUserId(code, userId));
        }
        [HttpPost]
        public async Task<IActionResult> Save(Models.Discount discount)
        {
            return CreateActionResultInstance(await _discountService.Save(discount));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            return CreateActionResultInstance(await _discountService.Update(discount));
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResultInstance(await _discountService.DeleteById(id));
        }

    }
}
