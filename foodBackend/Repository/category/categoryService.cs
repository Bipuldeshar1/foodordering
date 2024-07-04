using foodBackend.Data;
using foodBackend.Dtos.category;
using foodBackend.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace foodBackend.Repository.category
{
    public class categoryService : ICategory
    {
        private readonly AppDbContext context;

      public  categoryService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> AddCategory(categoryReg model, UserModel user)
        {
            var categoryExists = await context.categoryModels.FirstOrDefaultAsync(x => x.categoryName == model.categoryName);
            var u = user.Id;
            if (categoryExists !=null) {
                return new BadRequestObjectResult(new {msg="category already exists" });
            }
            else
            {
                if (user != null)
                {
                    var category = new CategoryModel
                    {
                        Id=Guid.NewGuid().ToString(),
                        categoryName = model.categoryName,
                        authorId = user.Id,
                    };

                    var result = await context.categoryModels.AddAsync(category);
                    await context.SaveChangesAsync();

                    var newCAtegory = await context.categoryModels.ToListAsync();

                    return new OkObjectResult(new { msg = "category addeed", newCAtegory });

                }
                else
                {
                    return new BadRequestObjectResult(new { msg = "unauthorized" });
                }
            }


        }

        public Task<IActionResult> DeleteCategory(CategoryModel model, UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetCategory()
        {
            var category = await context.categoryModels.ToListAsync();
            return new OkObjectResult(category);
        }

        public Task<IActionResult> UpdateCategory(CategoryModel model, UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
