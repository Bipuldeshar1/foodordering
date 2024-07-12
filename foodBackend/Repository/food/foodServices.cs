using foodBackend.Data;
using foodBackend.Dtos.food;
using foodBackend.models;
using foodBackend.utility.image;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace foodBackend.Repository.food
{
    public class foodServices : IFood
    {
        private readonly AppDbContext context;
        private readonly IImage image;

        public foodServices(AppDbContext context,IImage image)
        {
            this.context = context;
            this.image = image;
        }
        public async Task<IActionResult> addFood(foodReg model, string id, string token)
        {
            var user = await context.userModels.FirstOrDefaultAsync(x=>x.Id==id);
            if(user == null)
            {
                return new BadRequestObjectResult(new { msg = "user not ofund" });
            }
            var category= await context.categoryModels.FirstOrDefaultAsync(x=>x.categoryName==model.categoryName);
            if (category == null)
            {
                return new BadRequestObjectResult(new { msg = "Category not found" });
            }
            string imageUrl = "";
            if (model.imageUrl != null && model.imageUrl.Length > 0)
            {
                var uploadResult = await image.UploadToCloudinary(model.imageUrl);
                imageUrl = uploadResult.Url.ToString();
;            }


            var fmodel =new foodModel {
                Id=Guid.NewGuid().ToString(),
                name=model.name,
                description=model.description,
                imageUrl= imageUrl,
                price = int.Parse(model.price),
                quantity= int.Parse(model.quantity),
                address =model.address,
                outOfStock=model.outOfStock,
                authorId=user.Id,
                categoryId=category.Id,
            };
            var food = await context.foodModels.AddAsync(fmodel);
            await context.SaveChangesAsync();
            return new OkObjectResult(new { msg = "added success"});
        }

        public async Task<IActionResult> deleteFood(foodUpdate model, string id)
        {
            var user = await context.userModels.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return new BadRequestObjectResult(new { msg = "user not ofund" });
            }
            var food= await context.foodModels.FirstOrDefaultAsync(x=>x.Id==model.Id);
            if (food == null) {
                return new BadRequestObjectResult("food not found");
            }
            if(food.authorId==user.Id)
            {
                context.foodModels.Remove(food);
                 context.SaveChanges();
                return new OkObjectResult("deleted success");
            }
            else
            {
                return new BadRequestObjectResult("unauthorized");
            }
        }

        public async Task<IActionResult> getFood()
        {
           var foods= await context.foodModels.ToListAsync();
          

            return new OkObjectResult(foods);
        }


        public async Task<IActionResult> updateFood(foodUpdate model, string id)
        {
            var user = await context.userModels.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return new BadRequestObjectResult(new { msg = "user not ofund" });
            }
            var food = await context.foodModels.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (food == null)
            {
                return new BadRequestObjectResult("food not found");
            }

            var category = await context.categoryModels.FirstOrDefaultAsync(x => x.Id == model.categoryId);
            if (category == null)
            {
                return new BadRequestObjectResult(new { msg = "Category not found" });
            }
            if (food.authorId == user.Id)
            {
                string imageUrl = "";
                if (model.imageUrl != null || model.imageUrl.Length > 0)
                {
                    imageUrl = await image.UploadImageAsync(model.imageUrl);
                }
                food.name = model.name;
                food.description = model.description;
                food.imageUrl = imageUrl;
                food.price = model.price;
                food.quantity = model.quantity;
                food.address = model.address;
                food.outOfStock = model.outOfStock;
                food.authorId = user.Id;
                food.categoryId = category.Id;
                
                context.SaveChanges();

                return new OkObjectResult(new { msg = "updated success"});
            }
            else
            {
                return new BadRequestObjectResult("unauthorized");
            }
          
        }
    }
}
