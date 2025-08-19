using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Auths.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; } = null!;         // Email
        public string Password { get; set; } = null!;  // Password
    }
}
