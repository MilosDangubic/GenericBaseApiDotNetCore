using BaseApi.Configuration;
using BaseApi.Core.Service;
using BaseApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Controllers
{
    public class UserController : DefaultController<User>
    {
        public UserController(ProjectConfiguration configuration,  IUserService userService) : base(configuration, userService)
        {
            
        }
    }
}
