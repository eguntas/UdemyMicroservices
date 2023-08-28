using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        //Shared projesini 3.1 olarak oluştur o yüzden hata alınıyor
        //[HttpPost]
        //public async Task<IActionResult> SignUp(SignupDto dto)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = dto.UserName,
        //        Email = dto.Email

        //    };
        //    var result = _userManager.CreateAsync(user, dto.Password);


        //}
    }
}
