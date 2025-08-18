using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.DTOs.Auth
{
    public class RegisterDto
    {
        public string Username { get; set; } = null!;     // Username
        public string Email { get; set; } = null!;        // Email
        public string Password { get; set; } = null!; // Password
        public string FirstName { get; set; } = null!;    // First name
        public string LastName { get; set; } = null!;     // Last name
        public string PhoneNumber { get; set; } = null!;  // Phone number
        public string? ProfileImageUrl { get; set; }      // Profile image URL (optional)
        public string? Address { get; set; }              // Address (optional)
    }
}
