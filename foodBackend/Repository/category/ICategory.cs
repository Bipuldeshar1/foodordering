using foodBackend.Dtos.category;
using foodBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.category
{
    public interface ICategory
    {

        public Task<IActionResult> AddCategory(categoryReg model, UserModel user);
        public Task<IActionResult> GetCategory();
        public Task<IActionResult> UpdateCategory(CategoryModel model, UserModel user);
        public Task<IActionResult> DeleteCategory(string id, UserModel user);
    }
}
