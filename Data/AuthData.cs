using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace fitness_tracker_api.Data
{
    public class AuthData : IAuthRepo
    {
        public AuthData(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        private readonly List<UserModel> users = new List<UserModel> 
        {   
            new UserModel { name = "arun", emailId = "arunjoshi@gmail.com", password = "arun1234" }, 
            new UserModel { name = "test", emailId = "test@gmail.com", password = "test123" }
        };
        private readonly AppSettings _appSettings;

        public UserModel Authenticate(string emailId, string password)
        {
            var user = users.SingleOrDefault(u => u.emailId == emailId && password == u.password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.emailId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            user.password = null;
            return user;
        }
    }
}
