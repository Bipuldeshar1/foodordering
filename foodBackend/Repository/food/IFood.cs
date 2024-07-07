using foodBackend.Dtos.food;
using foodBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.food
{
    public interface IFood
    {
        public Task<IActionResult> addFood(foodReg model,string id,string token);

        public Task<IActionResult> getFood();

        public Task<IActionResult> updateFood(foodUpdate model, string id);

        public Task<IActionResult> deleteFood(foodUpdate model, string id);
       
    }
}
