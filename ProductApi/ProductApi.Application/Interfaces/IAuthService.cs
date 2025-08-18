using ProductApi.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult<string>> RegisterAsync(RegisterDto dto);
        Task<ServiceResult<string>> LoginAsync(LoginDto dto);
    }
}
