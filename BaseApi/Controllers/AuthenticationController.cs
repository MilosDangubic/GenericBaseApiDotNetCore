using BaseApi.Configuration;
using BaseApi.Controllers.Requests;
using BaseApi.Core.Service;
using BaseApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Controllers
{
    public class AuthenticationController : DefaultController<User>
    {
        private readonly IAuthenticationService authenticationService;
        public AuthenticationController(ProjectConfiguration configuration, IAuthenticationService authenticationService, IUserService userService) : base(configuration, userService)
        {
            this.authenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(LoginRequest loginRequest) 
        {
            if(loginRequest == null || loginRequest.Email==null || loginRequest.Password == null) 
            {
                return BadRequest();
            }
            if(loginRequest.CliendId != configuration.Jwt.ClientId || loginRequest.ClientSecret != configuration.Jwt.ClientSecret) 
            {
                return BadRequest();
            }
            JwtSecurityToken token = authenticationService.UserAuthentication(loginRequest.Email,loginRequest.Password);
            if (token == null) 
            {
                return BadRequest("Invalid credentials");
            }
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
