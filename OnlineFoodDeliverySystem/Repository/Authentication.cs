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
            var r = _context.Customers.FirstOrDefault(t => t.Email == email && t.Password == password);
            if (r == null)
            {
                return null;
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, email)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }
    }
}