using foodBackend.Data;
using foodBackend.Dtos;
using foodBackend.Dtos.food;
using foodBackend.models;
using foodBackend.Repository.food;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public Task<IActionResult> addFood([FromForm]foodReg model) {
            var token = HttpContext.Request.Headers["Authorization"];
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            return food.addFood(model, userIdClaim!);
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
            return food.updateFood(model,userIdClaim!);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public Task<IActionResult> deleteFood([FromRoute]string id )
        {
           
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return food.deleteFood(id,userIdClaim!);
        }


        [HttpGet("getById/{id}")]
        [Authorize]
        public Task<IActionResult> getById([FromRoute]string id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return food.getById(id,userIdClaim);
        }
    }
}
