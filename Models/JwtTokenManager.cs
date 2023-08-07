using GerenciamentoContatos.Data.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoContatos.Models
{
    public class JwtTokenManager : ITokenManager
    {
        private IConfigurationRoot _configBuilder;

        public JwtTokenManager()
        {
            _configBuilder = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build(); ;
        }
        public void Decode()
        {
            throw new NotImplementedException();
        }

        public string Generate(CreatedUserDto dto)
        {
            var secretKey = _configBuilder["TokenKey"];

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, dto.Name),
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim("Id", dto.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        public bool Validate(string token)
        {
            var secretKey = _configBuilder["TokenKey"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

