using BaseApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Core
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithEmail(string email);
        User Get(int id);
        User GetUserWithRegistrationToken(string token);

        User GetUserWithResetToken(string token);
        User GetUserWithEmailAndPassword(string email, string password);
        IEnumerable<User> getAllReqruites();

    }
}
