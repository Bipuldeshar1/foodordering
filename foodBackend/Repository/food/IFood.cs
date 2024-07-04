using foodBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.food
{
    public interface IFood
    {
        public Task<IActionResult> addFood(foodModel model,string id);

        public Task<IActionResult> getFood();

        public Task<IActionResult> updateFood(foodModel model, string id);

        public Task<IActionResult> deleteFood(foodModel model, string id);
       
    }
}
