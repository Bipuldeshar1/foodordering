using foodBackend.models;
using foodBackend.Repository.food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public Task<IActionResult> addFood(foodModel model) {
            return null;
        }
        public Task<IActionResult> getFood()
        {
            return null;
        }
        public Task<IActionResult> updateFood(foodModel model)
        {
            return null;
        }
        public Task<IActionResult> deleteFood(foodModel model)
        {
            return null;
        }
    }
}
