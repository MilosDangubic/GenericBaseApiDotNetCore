using BaseApi.Configuration;
using BaseApi.Core.Service;
using BaseApi.Model;
using BaseApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Service
{
    public class UserService : BaseEntityService<User>, IUserService
    {
        public UserService(ProjectConfiguration projectConfiguration) :base (projectConfiguration) { }

        public User GetUserWithEmail(string email) 
        {
            try 
            {
                using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
                {
                    return unitOfWork.Users.GetUserWithEmail(email);
                }
                
            }
            catch (Exception e)
            {
                return null;
            }
        }

        
    }
}
