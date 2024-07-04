using System.ComponentModel.DataAnnotations;

namespace foodBackend.Dtos.auth
{
    public class LoginModel
    {
        [Required]
        public string email {  get; set; }
        [Required]
        public string password { get; set; }
    }
}
