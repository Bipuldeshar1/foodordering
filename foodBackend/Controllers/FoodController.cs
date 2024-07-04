using foodBackend.Dtos.food;
using foodBackend.models;
using foodBackend.Repository.food;
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

        public Task<IActionResult> addFood(foodReg model) {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            return food.addFood(model,userIdClaim);
        }
        public Task<IActionResult> getFood()
        {
            return food.getFood();
        }
        public Task<IActionResult> updateFood(foodUpdate model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return food.updateFood(model,userIdClaim);
        }
        public Task<IActionResult> deleteFood(foodUpdate model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return food.deleteFood(model,userIdClaim);
        }
    }
}
