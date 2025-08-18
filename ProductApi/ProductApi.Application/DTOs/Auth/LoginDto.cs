using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.DTOs.Auth
{
    public class LoginDto
    {
        public string Email { get; set; } = null!;         // Email
        public string Password { get; set; } = null!;  // Password
    }
}
