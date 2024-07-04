using foodBackend.Dtos;
using foodBackend.models;
using foodBackend.Repository.category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory category;

        CategoryController(ICategory category)
        {
            this.category = category;
        }
        public Task<IActionResult> AddCategory(categoryReg model) {
            return category.AddCategory(model);
        }
        public Task<IActionResult> GetCategory() {
            return category.GetCategory();
                }

        public Task<IActionResult>UpdateCategory(CategoryModel model) { 
        return category.UpdateCategory(model);
        }
        public Task<IActionResult>DeleteCategory(CategoryModel model) {
            return category.DeleteCategory(model);
        
        }

    }
}
