﻿using System.ComponentModel.DataAnnotations;

namespace foodBackend.Dtos.auth
{
    public class RegisterModel
    {
    
        public string? Name { get; set; }
  
        public string? Email { get; set; }
 
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
        public string? Role { get; set; }
    }
}
