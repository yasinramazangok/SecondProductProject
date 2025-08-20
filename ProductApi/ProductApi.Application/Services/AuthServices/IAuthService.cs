using ProductApi.Application.Commons.Models;
using ProductApi.Application.Features.Auths.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ServiceResult<string>> RegisterAsync(RegisterDto dto);
        Task<ServiceResult<string>> LoginAsync(LoginDto dto);
    }
}
