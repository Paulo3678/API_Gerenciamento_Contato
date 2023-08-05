using GerenciamentoContatos.Data.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoContatos.Models
{
    public class JwtTokenManager : ITokenManager
    {
        public void Decode()
        {
            throw new NotImplementedException();
        }

        public string Generate(CreatedUserDto dto)
        {
            string secretKey = "9UMmL6f#g0D#cxLzYR%dBdNoY1cGO0eUEb8nH0t";

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, dto.Name),
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim("Id", dto.Email)
            };


            // Configurar a chave de segurança
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            // Configurar o token
            var token = new JwtSecurityToken(
                issuer: "seu-site.com",
                audience: "seu-site.com",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Definir tempo de expiração
                signingCredentials: credenciais
            );

            // Escrever o token como string
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
