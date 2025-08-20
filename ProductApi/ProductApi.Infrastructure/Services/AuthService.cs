using Microsoft.EntityFrameworkCore;
using ProductApi.Application.Commons.Models;
using ProductApi.Application.Features.Auths.DTOs;
using ProductApi.Application.Services.AuthServices;
using ProductApi.Core.Entities;
using ProductApi.Core.Enums;
using ProductApi.Infrastructure.Contexts;
using ProductApi.Infrastructure.Identity;

namespace ProductApi.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ProductApiDbContext _context;
        private readonly JwtTokenService _jwtService;

        public AuthService(ProductApiDbContext context, JwtTokenService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<ServiceResult<string>> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return ServiceResult<string>.Fail("Bu email zaten kayıtlı!");

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = Role.User, // Default role is User, can be changed later
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                ProfileImageUrl = dto.ProfileImageUrl,
                Address = dto.Address
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return ServiceResult<string>.Success("Kullanıcı başarıyla kaydedildi!");
        }

        public async Task<ServiceResult<string>> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return ServiceResult<string>.Fail("Kimlik doğrulama hatası!");

            var token = _jwtService.GenerateToken(user);
            return ServiceResult<string>.Success(token);
        }
    }
}
