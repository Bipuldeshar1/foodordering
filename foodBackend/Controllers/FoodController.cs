using foodBackend.Data;
using foodBackend.Dtos.food;
using foodBackend.models;
using foodBackend.Repository.food;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace foodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFood food;
        private readonly AppDbContext context;

        public FoodController(IFood food,AppDbContext context)
        {
            this.food = food;
            this.context = context;
        }

        [HttpPost("add")]
        [Authorize]
        public Task<IActionResult> addFood(foodReg model) {
            var token = HttpContext.Request.Headers["Authorization"];

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return food.addFood(model, userIdClaim!,token);
        }

        [HttpGet("get")]
        [Authorize]
        public Task<IActionResult> getFood()
        {
            return food.getFood();
        }

        [HttpPut("update")]
        [Authorize]
        public Task<IActionResult> updateFood([FromForm] foodUpdate model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return food.updateFood(model,userIdClaim!);
        }

        [HttpDelete("delete")]
        [Authorize]
        public Task<IActionResult> deleteFood(foodUpdate model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return food.deleteFood(model,userIdClaim!);
        }
    }
}
