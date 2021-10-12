using BaseApi.Configuration;
using BaseApi.Core.Service;
using BaseApi.Model;
using BaseApi.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseApi.Service
{
    public class AuthenticationService : BaseEntityService<User>, IAuthenticationService
    {
       // public AuthenticationService(): base() { }
        public AuthenticationService(ProjectConfiguration configuration) : base(configuration) { }

        
        public JwtSecurityToken UserAuthentication(string email,string password)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(new ApplicationContext());
            User user = unitOfWork.Users.GetUserWithEmail(email);
            if (user == null || !user.Enabled || !BCrypt.Net.BCrypt.Verify(password, user.Password)) 
            {
                return null;
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,configuration.Jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("Id",user.Id.ToString()),
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName),
                new Claim("Email",user.Email)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration.Jwt.Issuer, configuration.Jwt.Audience, claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
            return token;
        }
    }
}
