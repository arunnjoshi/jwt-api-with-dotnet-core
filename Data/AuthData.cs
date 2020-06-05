using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
            new UserModel { name = "arun", emailId = "arunjoshi@gmail.com", password = "F3BF87CDFA1F383A2E0C4B90FE65724225DD3D6C96071658F643F1C7AA248E8CD5B1833A61178294E01E899F4795651E291053C3ECB82952DB588636B37F0AE1" },
            new UserModel { name = "test", emailId = "test@gmail.com", password = "test123" }
        };

        private readonly AppSettings _appSettings;

        //hashing password
        private string CreateHash(string plainText)
        {
            SHA512 hashSvc = SHA512.Create();
            byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return BitConverter.ToString(hash).Replace("-", "");
        }

        //Authenticate
        public UserModel Authenticate(string emailId, string password)
        {
            var user = users.SingleOrDefault(u => u.emailId == emailId);
            if (user == null)
                return null;
            if (user.password == CreateHash(password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.emailId.ToString())
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.token = tokenHandler.WriteToken(token);
                user.password = CreateHash(user.password);
                user.password = null;
                return user;
            }
            return null;
        }
    }
}