using foodBackend.Dtos;
using foodBackend.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public Task<IActionResult> AddCategory(categoryReg model) { }
        public Task<IActionResult> GetCategory() { }

        public Task<IActionResult>UpdateCategory(CategoryModel model) { }
        public Task<IActionResult>DeleteCategory(CategoryModel model) { }

    }
}
