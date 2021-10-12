using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Controllers.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CliendId { get; set; }
        public string ClientSecret { get; set; }

        public LoginRequest() { }
        public LoginRequest(string email,string password,string clientId,string clientSecret) 
        {
            this.Email = email;
            this.Password = password;
            this.CliendId = clientId;
            this.ClientSecret = clientSecret;
        }
    }
}
