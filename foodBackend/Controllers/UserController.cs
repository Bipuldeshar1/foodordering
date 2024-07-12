using CloudinaryDotNet.Actions;
using foodBackend.Data;
using foodBackend.Dtos.auth;
using foodBackend.models;
using foodBackend.Repository.auth;
using foodBackend.utility.image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Claims;



namespace foodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly UserManager<UserModel> userManager;
        private readonly IAuth auth;
        private readonly IImage img;

        public UserController(AppDbContext context,UserManager<UserModel> userManager,IAuth auth,IImage img)
        {
            this.context = context;
            this.userManager = userManager;
            this.auth = auth;
            this.img = img;
        }



        [HttpPost("register")]
        public Task<IActionResult> Register( RegisterModel model) {
        
            return auth.Register(model);
            
        }


        [HttpPost("login")]
        public Task<IActionResult> login( LoginModel model)
        {
            return auth.login(model);
        }

  
        [HttpGet("currentUser")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await context.userModels.FirstOrDefaultAsync(u => u.Id == userIdClaim);
            if (user == null)
            {
                return Ok("Invalid");
            }
            else
            {
                return Ok(user);
            }

        }


        [HttpGet("user")]
    
        public IEnumerable<UserModel> get()
        {
            return auth.get();
           
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return await auth.Logout();
        }

        [HttpPost("imgTest")]
        public Task<ImageUploadResult> imgTest(IFormFile file)
        {
            return img.UploadToCloudinary(file);
                
        }

    }
}
