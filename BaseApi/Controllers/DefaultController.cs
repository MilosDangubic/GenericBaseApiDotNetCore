using BaseApi.Configuration;
using BaseApi.Core.Service;
using BaseApi.Model;
using BaseApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController<TEntity> : ControllerBase where TEntity : class  
    {
        protected ProjectConfiguration configuration;
        protected readonly IUserService userService;
        protected readonly IBaseEntityService<TEntity> baseService;

        public DefaultController(ProjectConfiguration configuration, IUserService userService) 
        {
            this.configuration = configuration;
            this.userService = userService;
            this.baseService = userService as IBaseEntityService<TEntity>;
        }

        private User GetCurrentUser() 
        {
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
            return userService.GetUserWithEmail(email);
        }

        [HttpGet("{id}")]
        public  virtual async Task<IActionResult> Get(int id) 
        {
            TEntity entity = baseService.Get(id);

            if (entity == null) 
            {
                return BadRequest();
            }

            return Ok(entity);
        }
        [HttpDelete("{id}")]
        public virtual async  Task<IActionResult> Delete(int id) 
        {
            if (!baseService.Delete(id)) 
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
