using foodBackend.Dtos.food;
using foodBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.food
{
    public class foodServices : IFood
    {
        public Task<IActionResult> addFood(foodReg model, string id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> deleteFood(foodUpdate model, string id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> getFood()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> updateFood(foodUpdate model, string id)
        {
            throw new NotImplementedException();
        }
    }
}
