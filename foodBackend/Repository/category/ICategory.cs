using foodBackend.Dtos;
using foodBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.category
{
    public interface ICategory
    {

        public Task<IActionResult> AddCategory(categoryReg model);
        public Task<IActionResult> GetCategory();
        public Task<IActionResult> UpdateCategory(CategoryModel model);
        public Task<IActionResult> DeleteCategory(CategoryModel model);
    }
}
