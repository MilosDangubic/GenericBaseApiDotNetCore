using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Core.Service
{
    public interface IAuthenticationService
    {
        public JwtSecurityToken UserAuthentication(string email, string password);

    }
}
