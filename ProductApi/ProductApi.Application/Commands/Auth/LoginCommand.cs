using ProductApi.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Commands.Auth
{
    public class LoginCommand
    {
        public LoginDto LoginDto { get; set; } // Contains login credentials

    }
}
