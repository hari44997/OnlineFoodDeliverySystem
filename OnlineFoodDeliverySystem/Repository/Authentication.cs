using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Repository
{
    public class Authentication : IAuthentication
    {
        private readonly string key;
        private readonly FoodDbContext _context;

        public Authentication(FoodDbContext context, string key)
        {
            _context = context;
            this.key = key;
        }

        public string Authenticate(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.EmailAddress == email && u.Password == password);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Names.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}