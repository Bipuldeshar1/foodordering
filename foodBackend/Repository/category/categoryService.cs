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

        public async Task<IActionResult> DeleteCategory(string id, UserModel user)
        {
            var model = await context.categoryModels.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return new BadRequestObjectResult(new { msg = "category not found" });
            }

            if (model.authorId == user.Id)
            {
                context.categoryModels.Remove(model);
                await context.SaveChangesAsync();
                return new OkObjectResult(new { msg = "success delete" });
            }

            return new BadRequestObjectResult(new { msg = "unauthorized" });
        }

        public async Task<IActionResult> GetCategory(UserModel user)
        {
            if (user == null)
            {
                return new BadRequestObjectResult(new { msg = "user not found" });
            }
            
            var category = await context.categoryModels.Where(c=>c.authorId==user.Id).ToListAsync();
            
            return new OkObjectResult(category);
        }

        public async Task<IActionResult> UpdateCategory(CategoryUpdate model, UserModel user)
        {
            var category= await context.categoryModels.FirstOrDefaultAsync(x=>x.Id==model.Id);

            if(category == null)
            {
                return new BadRequestObjectResult(new { msg = "not found" });
            }
            else
            {
                if (category.authorId == user.Id)
                {
                    if (category.Id == model.Id)
                    {
                        category.categoryName = model.CategoryName;
                        await context.SaveChangesAsync();
                        return new OkObjectResult(new { msg = "success" });
                    }
                    else
                    {
                        return new BadRequestObjectResult(new { msg = "cannot" });
                    }
                }
                else
                {
                    return new BadRequestObjectResult(new { msg = "unauthorized" });
                }
            }
        }
    }
}
