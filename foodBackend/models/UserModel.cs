using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace foodBackend.models
{
    public class UserModel:IdentityUser
    {
     
        [Required]
        public string Name { get;set; }
      
    
        public string Password { get;set; }
 
        public string PhoneNumber { get;set; }

        public string Address { get;set; }
        public string? Role { get;set; }

        public ICollection<foodModel> foodModels { get;set; }
      
    }
}
