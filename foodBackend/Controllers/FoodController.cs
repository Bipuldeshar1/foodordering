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

     
        public FoodController(IFood food)
        {
            this.food = food;
        }

        [HttpPost("add")]
        [Authorize]
        public Task<IActionResult> addFood([FromForm] foodReg model) {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            return food.addFood(model,userIdClaim);
        }

        [HttpGet("get")]
        public Task<IActionResult> getFood()
        {
            return food.getFood();
        }

        [HttpPut("update")]
        [Authorize]
        public Task<IActionResult> updateFood([FromForm] foodUpdate model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return food.updateFood(model,userIdClaim);
        }

        [HttpDelete("delete")]
        [Authorize]
        public Task<IActionResult> deleteFood(foodUpdate model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return food.deleteFood(model,userIdClaim);
        }
    }
}
