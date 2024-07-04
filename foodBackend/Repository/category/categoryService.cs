using foodBackend.Dtos;
using foodBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.category
{
    public class categoryService : ICategory
    {
        public Task<IActionResult> AddCategory(categoryReg model)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteCategory(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetCategory()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateCategory(CategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
