using ProductApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }                        // Primary key
        public string Username { get; set; }               // Username
        public string Email { get; set; }                  // Email address
        public string Password { get; set; }           // Password
        public Role Role { get; set; }                     // Admin / User role
        public string FirstName { get; set; }              // First name
        public string LastName { get; set; }               // Last name
        public string PhoneNumber { get; set; }            // Phone number
        public bool IsActive { get; set; } = true;        // Is user active?
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Creation date
        public DateTime? LastLogin { get; set; }           // Last login time
        public string ProfileImageUrl { get; set; }        // Profile image URL
        public string Address { get; set; }                // Address (optional)
    }
}
