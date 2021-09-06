using System;
using System.Security.Claims;
using System.Text;
using CustomMiddleware.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace CustomMiddleware.Services
{
    class SecurityService : ISecurityService
    {
        public string GenerateToken(Claim[] claims) {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyz"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = "itvitae.nl",
                Audience = "aud",
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string ComputeHash(string password, string salt) {
            var pwb = Encoding.UTF8.GetBytes(password);
            var sb = Encoding.UTF8.GetBytes(salt);
            var hash = new Rfc2898DeriveBytes(pwb, sb, 10000);

            return Convert.ToBase64String(hash.GetBytes(24));
        }

        public string GenerateSalt() {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

    }
}