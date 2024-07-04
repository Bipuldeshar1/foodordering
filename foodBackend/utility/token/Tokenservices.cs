using foodBackend.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace foodBackend.utility.token
{
    public class Tokenservices : IToken
    {
        private readonly IConfiguration configuration;

        public Tokenservices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
  
        public string GenerateToken(UserModel user)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var id = user.Id;

            var claims = new[]
       {
            new Claim("userId", user.Id),
            new Claim("userName", user.Name),
            
        };

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims:claims,
                    expires: DateTime.Now.AddMinutes(15),
                     signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       
    }
}
