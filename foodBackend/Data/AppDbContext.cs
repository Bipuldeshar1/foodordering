using foodBackend.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace foodBackend.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
         public DbSet<UserModel> userModels { get; set; }

        public DbSet<CategoryModel> categoryModels { get; set; }

        public DbSet<foodModel> foodModels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<foodModel>()
                .HasOne(f => f.userModel)
                .WithMany(u => u.foodModels)
                .HasForeignKey(u => u.authorId);

            builder.Entity<foodModel>()
                .HasOne(f => f.category)
                .WithMany(c => c.foodModels)
                .HasForeignKey(f => f.categoryId);

        //    builder.Entity<IdentityRole>().HasData(
        //    new IdentityRole
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "Admin",
        //        NormalizedName = "Admin"
        //    },
        //    new IdentityRole
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "User",
        //        NormalizedName = "User"
        //    }

        //); 

        }
    } 
}

