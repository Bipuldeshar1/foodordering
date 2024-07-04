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

     
        public string  GenerateToken(UserModel user)
        {
            DateTime currentDateTime = DateTime.UtcNow;
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Iat, currentDateTime.ToString()),  
                    new Claim(JwtRegisteredClaimNames.Iss,  configuration["Jwt:Issuer"]),
                    new Claim(JwtRegisteredClaimNames.Aud,   configuration["Jwt:Audience"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  
                }),
                Expires = DateTime.Now.AddMinutes(15),
               
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256)
            };

            SecurityToken jwtToken = jwtTokenHandler.CreateToken(tokenDescriptor);
            String jwtStringToken = jwtTokenHandler.WriteToken(jwtToken);

            return jwtStringToken;


            
        }

    }
}
