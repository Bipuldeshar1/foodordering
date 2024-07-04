using foodBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.food
{
    public interface IFood
    {
        public Task<IActionResult> addFood(foodModel model,UserModel user);

        public Task<IActionResult> getFood();

        public Task<IActionResult> updateFood(foodModel model, UserModel user);

        public Task<IActionResult> deleteFood(foodModel model, UserModel user);
       
    }
}
