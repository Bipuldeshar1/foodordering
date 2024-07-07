using foodBackend.Data;
using foodBackend.Dtos.auth;
using foodBackend.models;
using foodBackend.Repository.auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthServices : IAuth
{
    private readonly AppDbContext context;
    private readonly UserManager<UserModel> userManager;
    private readonly SignInManager<UserModel> signInManager;
    private readonly IConfiguration configuration;

    public AuthServices(AppDbContext context, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IConfiguration configuration)
    {
        this.context = context;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.configuration = configuration;
    }

    public async Task<IActionResult> login(LoginModel model)
    {
        var user = await userManager.FindByEmailAsync(model.email);
        if (user == null)
        {
            return new BadRequestObjectResult(new { msg = "User does not exist" });
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, model.password, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["JwtConfig:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration["JwtConfig:Issuer"],
                Audience = configuration["JwtConfig:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new OkObjectResult(new { msg = "Success Login", token = tokenString });
        }
        else
        {
            return new BadRequestObjectResult(new { msg = "Failed login" });
        }
    }

    public async Task<IActionResult> Register(RegisterModel model)
    {
        var emailExists = context.userModels.FirstOrDefault(u => u.Email == model.Email);
        if (emailExists != null)
        {
            return new BadRequestObjectResult(new { msg = "user already exists" });
        }

        var user = new UserModel
        {
            UserName = model.Name,
            Name = model.Name,
            Email = model.Email,
            Address = model.Address,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            Role = model.Role ?? "User",
        };
        var result = await userManager.CreateAsync(user, model.Password);
        await context.SaveChangesAsync();

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, model.Role ?? "User");
            await context.SaveChangesAsync();
            await signInManager.SignInAsync(user, isPersistent: false);
            return new OkObjectResult(new { message = "Registration successful" });
        }
        else
        {
            var errors = new SerializableError();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Code, error.Description);
            }
            return new BadRequestObjectResult(new { message = "Failed to register user", errors });
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
