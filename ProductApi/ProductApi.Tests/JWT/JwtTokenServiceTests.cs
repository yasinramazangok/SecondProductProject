using ProductApi.Core.Entities;
using ProductApi.Infrastructure.Identity;
using System.IdentityModel.Tokens.Jwt;
using Xunit;

namespace ProductApi.Tests.JWT
{
    public class JwtTokenServiceTests
    {
        [Fact]
        public void GenerateToken_ShouldReturn_ValidJwt()
        {
            // Arrange
            var user = new User { UserId = 12, Username = "testuser", Email = "deneme@deneme.com" };
            var tokenService = new JwtTokenService("SecondProductProject12345!@#$!@#$!@#$", "ProductApi", "ProductApiUsers", 60);

            // Act
            var token = tokenService.GenerateToken(user);

            // Assert
            Assert.False(string.IsNullOrEmpty(token), "Token üretilmedi!");

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            Assert.Equal(user.Username, jwt.Claims.First(c => c.Type == "unique_name").Value);
            Assert.Equal(user.UserId.ToString(), jwt.Claims.First(c => c.Type == "sub").Value);

        }
    }
}
