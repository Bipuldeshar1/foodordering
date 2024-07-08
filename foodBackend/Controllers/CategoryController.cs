using foodBackend.Data;
using foodBackend.Dtos.category;
using foodBackend.models;
using foodBackend.Repository.category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace foodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory category;
        private readonly AppDbContext context;

       public CategoryController(ICategory category,AppDbContext context)
        {
            this.category = category;
            this.context = context;
        }

        [HttpPost("add")]
        [Authorize]
        public Task<IActionResult> AddCategory(categoryReg model) {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user =  context.userModels.FirstOrDefault(u => u.Id == userIdClaim);
            return category.AddCategory(model,user);
        }


        [HttpGet("get")]
        [Authorize]
        public Task<IActionResult> GetCategory() {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            var user = context.userModels.FirstOrDefault(u => u.Id == userIdClaim);
            var u = context.userModels.FirstOrDefault(u => u.Email == email);
            return category.GetCategory(user);
                }


        [HttpPut("update")]
        [Authorize]
        public Task<IActionResult> UpdateCategory(CategoryUpdate model) {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = context.userModels.FirstOrDefault(u => u.Id == userIdClaim);
            return category.UpdateCategory(model,user);
        }


        [HttpDelete("delete/{id}")]
        [Authorize]
        public Task<IActionResult> DeleteCategory([FromRoute]string id) {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = context.userModels.FirstOrDefault(u => u.Id == userIdClaim);
            return category.DeleteCategory(id,user);
        
        }

    }
}
