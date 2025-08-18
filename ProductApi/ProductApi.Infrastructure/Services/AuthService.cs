using ProductApi.Application.DTOs.Auth;
using ProductApi.Application.Interfaces;
using ProductApi.Core.Entities;
using ProductApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> _user;
        private readonly JwtTokenService _jwtService;

        public AuthService(IGenericRepository<User> user, JwtTokenService jwtService)
        {
            _user = user;
            _jwtService = jwtService;
        }

        public async Task RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = registerDto.Password, 
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber,
                ProfileImageUrl = registerDto.ProfileImageUrl
            };

            await _user.InsertAsync(user);
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            // Simplified login for task purposes
            var user = await _user.FindAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            var matchedUser = user.FirstOrDefault();
            if (matchedUser == null)
                throw new Exception("Geçersiz kimlik bilgileri!");

            return _jwtService.GenerateToken(matchedUser);
        }
    }
}
