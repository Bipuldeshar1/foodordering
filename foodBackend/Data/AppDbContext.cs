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


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

         

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

