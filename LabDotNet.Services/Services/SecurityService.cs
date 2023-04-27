using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LabDotNet.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;

namespace LabDotNet.Services.Services
{
    public class SecurityService : ISecurityService
    {
        public readonly string _passwordSalt = "u3#?!YS_Z,u:hKBdz,ef22N5MKe5]J0298wuie#:ans$utj%";
        public readonly string _jwtSecret = "W]za@%r'BE*VAJ4XVuqXst(3kmp0298wuie#:ans$utj%";
        public string GenerateJwtToken(long userId, string userEmail)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()), new Claim("email", userEmail)}),
                Expires = DateTime.UtcNow.AddDays(180),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string Hash(string text)
        {
            byte[] salt = Encoding.ASCII.GetBytes(_passwordSalt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: text,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                 iterationCount: 10000,
                 numBytesRequested: 256 / 8));

            return hashed;
        }

        public string HashSha256(string value)
        {
            throw new NotImplementedException();
        }

        public Guid ValidateJwtToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}