using foodBackend.Data;
using foodBackend.Dtos.auth;
using foodBackend.models;
using foodBackend.utility.token;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using System.Security.Claims;

namespace foodBackend.Repository.auth
{
    public class AuthServices : IAuth
    {
        private readonly AppDbContext context;
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;
        private readonly IToken token;

        public AuthServices(AppDbContext context,UserManager<UserModel> userManager,SignInManager<UserModel> signInManager,IToken token)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.token = token;
        }
        public async Task<IActionResult> login( LoginModel model)
        {
            var user = context.userModels.FirstOrDefault(u => u.Email == model.email);
            if (user == null)
            {
                return new BadRequestObjectResult(new { msg = "user doesnot exists" });
            }

            var result = await signInManager.PasswordSignInAsync(user.UserName!, model.password, false, false);
            if (result.Succeeded)
            {
               
                var t= token.GenerateToken(user);
                return new OkObjectResult(new { msg = "success Login" , token =t});
            }
            else
            {

                return new BadRequestObjectResult(new { msg = "failed login" });
            }


             
        }

      

        public async Task<IActionResult> Register( RegisterModel model)
        {
            var emailExists=   context.userModels.FirstOrDefault(u=>u.Email == model.Email);
            if (emailExists != null)
            {
                return new BadRequestObjectResult(new {msg="user already exists"});
            }

            var user = new UserModel
            {
                UserName=model.Name,
                Name=model.Name,
                Email=model.Email,
                Address=model.Address,
                Password=model.Password,
                PhoneNumber=model.PhoneNumber,
                Role=model.Role??"User",
            };
            var result = await userManager.CreateAsync(user, model.Password);
            await context.SaveChangesAsync();

            if(result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, model.Role ?? "User");
                await context.SaveChangesAsync();
              await  signInManager.SignInAsync(user,isPersistent:false);
                return new OkObjectResult(new { message = "Registration successful" });

            }
            else
            {
                var errors = new SerializableError();
                foreach(var error in result.Errors) {
                    errors.Add(error.Code, error.Description);
                        }
                return new BadRequestObjectResult(new { message = "Failed to register user",errors });
            }
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return new OkObjectResult(new { msg = "User logged out successfully" });
        }

        public IEnumerable<UserModel> get()
        {
            var user = context.userModels.ToList();
            return user;
        }

      
    }
}
