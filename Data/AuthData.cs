using System.IO;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace fitness_tracker_api.Data
{
	public class AuthData : IAuthRepo
	{
		private readonly AppSettings _appSettings;
		public AuthData(IOptions<AppSettings> appSettings)
		{ 
			_appSettings = appSettings;
		}
		List<UserModel> users = new List<UserModel> {
		new UserModel() { emailId = "arunjoshi@gmail.com", password = "arun1234", name = "arun joshi" },
		new UserModel() { emailId = "test@gmail.com", password = "test1234", name = "testman" },
	   };
		public UserModel Authenticate(string emailId, string password)
		{
			var user = this.users.FirstOrDefault(u => u.emailId == emailId && u.password == password);
			if (user == null)
				return null;

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
			  new Claim(ClaimTypes.Name,user.emailId),
			  new Claim(ClaimTypes.Version,"V3.1"),
		     }),
				Expires = DateTime.Now.AddDays(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			user.token = tokenHandler.WriteToken(token);
			user.password = null;
			return user;
		}
	}
}
