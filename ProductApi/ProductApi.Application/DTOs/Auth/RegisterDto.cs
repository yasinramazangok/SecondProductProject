using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.DTOs.Auth
{
    public class RegisterDto
    {
        public string Username { get; set; }    // Username
        public string Email { get; set; }       // Email
        public string Password { get; set; }    // Password
        public string FirstName { get; set; }   // First name
        public string LastName { get; set; }    // Last name
        public string PhoneNumber { get; set; } // Phone number
        public string ProfileImageUrl { get; set; } // Profile image URL
    }
}
