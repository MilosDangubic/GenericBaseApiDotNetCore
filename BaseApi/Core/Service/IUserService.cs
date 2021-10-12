using BaseApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Core.Service
{
    public interface IUserService : IBaseEntityService<User>
    {
        public User GetUserWithEmail(string email);

    }
}
